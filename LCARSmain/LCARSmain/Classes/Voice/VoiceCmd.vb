Option Strict On

Imports SpeechLib
Imports System.Text

Public MustInherit Class VoiceCmd
    Private _name As String
    Private _description As String
    Private _confirm As Boolean

    Public Sub New(ByVal name As String, ByVal description As String, ByVal confirm As Boolean)
        _name = name
        _description = description
        _confirm = confirm
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return _description
        End Get
    End Property

    Public ReadOnly Property RequiresConfirm() As Boolean
        Get
            Return _confirm
        End Get
    End Property

    Public MustOverride Sub Execute(ByVal result As SpeechLib.ISpeechRecoResult)

    Public MustOverride Sub BuildRule(ByRef builder As SpeechLib.ISpGrammarBuilder, ByRef hStateInitial As IntPtr)

    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder()
        builder.Append(_name.ToUpper())
        builder.Append(": ")
        builder.Append(Description)
        If _confirm Then
            builder.Append(" Requires confirmation")
        End If
        Return builder.ToString()
    End Function
End Class

Public Delegate Sub VoiceCmdSub(ByVal result As SpeechLib.ISpeechRecoResult)

Public Class InternalVoiceCmd
    Inherits VoiceCmd

    Private _func As VoiceCmdSub

    Public Sub New(ByVal name As String, ByVal description As String, ByVal func As VoiceCmdSub, ByVal confirm As Boolean)
        MyBase.New(name, description, confirm)
        _func = func
    End Sub

    Public Overrides Sub Execute(ByVal result As SpeechLib.ISpeechRecoResult)
        _func(result)
    End Sub

    Public Overrides Sub BuildRule(ByRef builder As SpeechLib.ISpGrammarBuilder, ByRef hStateInitial As System.IntPtr)
        Dim text As String = GetSetting("LCARS x32", "VoiceCommandAlias", Name, Name)
        builder.AddWordTransition(hStateInitial, Nothing, text, " ", SPGRAMMARWORDTYPE.SPWT_LEXICAL, 1, Nothing)
    End Sub
End Class

Public Class ExternalVoiceCmd
    Inherits VoiceCmd

    Private _command As String

    Public Sub New(ByVal name As String, ByVal description As String, ByVal command As String, ByVal confirm As Boolean)
        MyBase.New(name, description, confirm)
        _command = command
    End Sub

    Public Overrides Sub Execute(ByVal result As SpeechLib.ISpeechRecoResult)
        Try
            If IO.File.Exists(_command) Then
                'The command string is an absolute path.
                Dim myprocess As New Process
                myprocess.StartInfo.FileName = _command
                myprocess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(_command)
                myprocess.Start()
            Else
                'It isn't, so jump to the catch
                Throw New Exception
            End If
        Catch ex As Exception
            'The command will be interpreted as an absolute path, followed by arguments
            Try
                Dim myProcess As New Process()
                If (_command.Substring(0, 1) = """") Then
                    Dim splitIndex As Integer = _command.Substring(1).IndexOf("""") + 2
                    myProcess.StartInfo.FileName = _command.Substring(0, splitIndex)
                    myProcess.StartInfo.Arguments = _command.Substring(splitIndex + 1)
                    myProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(myProcess.StartInfo.FileName)
                Else
                    myProcess.StartInfo.FileName = _command.Split(" "c)(0)
                    myProcess.StartInfo.Arguments = _command.Substring(myProcess.StartInfo.FileName.Length + 1)
                    myProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(myProcess.StartInfo.FileName)
                End If
                myProcess.Start()
            Catch ex1 As Exception
                'Throw it to shell and see what happens.
                Try
                    Dim myID As Integer
                    myID = Shell(_command, AppWinStyle.NormalFocus)
                    Dim myprocess As Process = Process.GetProcessById(myID)
                Catch ex2 As Exception
                    'Throw it to Process.Start and hope for the best
                    Try
                        Dim myProcess As Process = Process.Start(_command)
                    Catch ex3 As Exception
                        MsgBox("Error: " & vbNewLine & vbNewLine & ex3.Message)
                    End Try
                End Try
            End Try
        End Try
    End Sub

    Public Overrides Sub BuildRule(ByRef builder As SpeechLib.ISpGrammarBuilder, ByRef hStateInitial As System.IntPtr)
        builder.AddWordTransition(hStateInitial, Nothing, Me.Name, " ", SPGRAMMARWORDTYPE.SPWT_LEXICAL, 1, Nothing)
    End Sub
End Class