function _execute(method, url, data, success, error, complete) {
    $.ajax({
        url: url,
        dataType: "json",
        data: data,
        type: method,
        contentType: "application/x-www-form-urlencoded",
        success: success,
        error: error,
        complete: complete
    });
}

function _get(url, data = null, success = null, error = null, complete = null) {
    _execute('get', url, data, success, error, complete);
}

function _post(url, data = null, success = null, error = null, complete = null) {
    _execute('post', url, data, success, error, complete);
}

function _patch(url, data = null, success = null, error = null, complete = null) {
    _execute('patch', url, data, success, error, complete);
}

function _delete(url, data = null, success = null, error = null, complete = null) {
    _execute('delete', url, data, success, error, complete);
}

const ajax = {
    get: _get,
    post: _post,
    patch: _patch,
    delete: _delete
}