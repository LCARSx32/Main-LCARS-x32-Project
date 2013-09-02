var mydiv = document.createElement("div");
var myImage = document.createElement("img");
window.onload = init;
function init(){
	//Get all images and add onclick handler
	var images = document.images;
	for(i=0; i < document.images.length; i++){
		document.images[i].onclick = onImageClick;
	}
	//Add div tag to show images in
	mydiv.id = "lightboxDiv";
	mydiv.className = "lightBox";
	mydiv.style.visibility = "hidden";
	mydiv.onclick = onLightboxClick;
	document.body.appendChild(mydiv);
	//Add image tag to use
	myImage.id = "lightboxImageTag";
	myImage.className = "lightboxImage";
	myImage.onclick = onLightboxClick;
	mydiv.appendChild(myImage);
}

function onImageClick(event){
	//Show div tag and set src to proper image
	event = event || window.event;
	var mytarget = event.target || event.srcElement;
	var source = mytarget.src;
	myImage.src = source;
	mydiv.style.visibility = "visible";
}

function onLightboxClick(){
	//Hide div tag
	mydiv.style.visibility = "hidden";
}