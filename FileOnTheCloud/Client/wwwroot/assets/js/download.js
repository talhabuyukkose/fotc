function downloadFile(mimetype, base64String, filename) {

    var filedataUrl = "data:" + mimetype + ";base64," + base64String;
    fetch(filedataUrl)
        .then(response => response.blob())
        .then(blob => {

            //create a link
            var link = window.document.createElement("a");
            link.href = window.URL.createObjectURL(blob, { type: mimetype });
            link.download = filename;

            //add, click and remove

            document.body.appendChild(link);
            link.click();

            document.body.removeChild(link);
        });
}