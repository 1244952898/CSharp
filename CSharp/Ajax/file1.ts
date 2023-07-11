function myAjax(url) {
    let prm = new Promise(function (resolve, reject) {
        let xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState != 4) {
                return;
            }
            if (xhr.readyState == 4 && xhr.status == 200) {
                resolve(xhr.responseText);
            } else {
                reject("服务器错误！");
            }
        }
        xhr.open('get', url);
        xhr.send(null);
    });
    return prm;
}