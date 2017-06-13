Option Strict On

Imports System.IO

''' <summary>
''' Contains methods to read and process .WAV files
''' </summary>
''' <remarks>
''' This is as accurate as possible, but it is likely that there exist valid, playable .WAV
''' files that this class cannot process.
''' </remarks>
Public Class WAVReader
    Private Sub New()
        'Prevent instantiation
    End Sub

    ''' <summary>
    ''' Constants for WAV data types
    ''' </summary>
    Private Enum WAVFormats As UInt16
        PCM = 1
        IEEE_FLOAT = 3
        ALAW = 6
        MULAW = 7
        EXTENSIBLE = &HFFFE
    End Enum

    ''' <summary>
    ''' Get the duration of the specified file
    ''' </summary>
    ''' <param name="file">File to process (must be openable)</param>
    ''' <returns>Duration in milliseconds. -1 on failure</returns>
    Public Shared Function GetLength(ByVal file As String) As Double
        ' This could be rewritten with BinaryReader to avoid all the manual conversions
        ' and error checks, but this works and is reliable.
        Dim length As Double = -1
        Try
            Using stream As New FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read)
                ' We aren't reading anything longer than 4 bytes, and all strings are 4 bytes long,
                ' so just reuse the same 4 byte buffer.
                Dim buffer(3) As Byte 'WHY does VB require that this be highest INDEX, not size?!

                'RIFF container format header
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim chunkID As String = System.Text.Encoding.ASCII.GetString(buffer)
                If chunkID <> "RIFF" Then Return -1

                'Size of RIFF chunk (Effectively file size - 8)
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim chunkSize As UInt32 = BitConverter.ToUInt32(buffer, 0)

                'Format type
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim format As String = System.Text.Encoding.ASCII.GetString(buffer)
                If format <> "WAVE" Then Return -1

                'Format chunk header
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim sc1ID As String = System.Text.Encoding.ASCII.GetString(buffer)
                'Yes, there is supposed to be a space at the end of "fmt ".
                If sc1ID <> "fmt " Then Return -1

                'Size of format chunk. This is important to make sure we read all of it.
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim sc1Len As UInt32 = BitConverter.ToUInt32(buffer, 0)
                ' No error check, but it should be 16, 18, or 40 in most cases

                'Audio data format
                If stream.Read(buffer, 0, 2) <> 2 Then Return -1
                Dim audioFormat As UInt16 = BitConverter.ToUInt16(buffer, 0)
                'We theoretically can handle any valid format, so no error check

                'Number of channels
                If stream.Read(buffer, 0, 2) <> 2 Then Return -1
                Dim nChannels As UInt16 = BitConverter.ToUInt16(buffer, 0)
                'Helpful if you need to play it, but not for us.

                'Sample rate
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim sampleRate As UInt32 = BitConverter.ToUInt32(buffer, 0)
                ' This could be used for our calculation, but we're going to rely on the next value

                'Bytes per second!
                If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                Dim byteRate As UInt32 = BitConverter.ToUInt32(buffer, 0)

                'Block alignment
                If stream.Read(buffer, 0, 2) <> 2 Then Return -1
                Dim blockAlign As UInt16 = BitConverter.ToUInt16(buffer, 0)
                'Another useful value, but not for us.

                'Bits per sample
                If stream.Read(buffer, 0, 2) <> 2 Then Return -1
                Dim bitsPerSample As UInt16 = BitConverter.ToUInt16(buffer, 0)
                'Another thing we aren't using

                'Read out any extra bytes describing the format
                If audioFormat <> WAVFormats.PCM Then
                    stream.Read(buffer, 0, 2)
                    Dim extraBytes As UInt16 = BitConverter.ToUInt16(buffer, 0)
                    stream.Seek(extraBytes, IO.SeekOrigin.Current)
                End If

                'Find the data chunk. Subsequent chunks are encoded as a 4-byte string followed by
                'a 4-byte integer with the length of the chunk.
                Dim chunkType As String
                Dim chunkLen As UInt32 = 0
                Do
                    'Seek to start of next chunk
                    stream.Seek(chunkLen, IO.SeekOrigin.Current)
                    'Get the chunk type
                    If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                    chunkType = System.Text.Encoding.ASCII.GetString(buffer)
                    'Get the chunk length
                    If stream.Read(buffer, 0, 4) <> 4 Then Return -1
                    chunkLen = BitConverter.ToUInt32(buffer, 0)
                Loop While chunkType <> "data"

                'Calculate the theoretical runtime of the file!
                'Number of bytes of data / bytes per second
                length = chunkLen / byteRate * 1000
            End Using
        Catch ex As IOException
            Return -1
        End Try
        Return length
    End Function

End Class
