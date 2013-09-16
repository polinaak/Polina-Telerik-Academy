window.requester = (function () {
    function getJSON(serviceUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            jQuery.ajax({
                url: serviceUrl,
                type: "GET",
                headers: headers,
                dataType: "json",
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(serviceUrl, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            jQuery.ajax({
                url: serviceUrl,
                dataType: "json",
                headers: { "X-accessToken": localStorage.getItem("accessToken") },
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(serviceUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            jQuery.ajax({
                url: serviceUrl,
                data: JSON.stringify(data),
                dataType: "json",
                type: "PUT",
                headers: headers,
                contentType: "application/json",
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    return {
        get: getJSON,
        post: postJSON,
        put: putJSON
    }
}());