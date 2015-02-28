
(function($, undefined) {
	window.ajax = function(method, url, data) {
		console.log("ajax", method, url, data);

		// default data to send
		var postData = {};

		postData = $.extend({}, postData, data);
		
		// add a cache-avoiding timestamp param
		url = addparamtourl(url, "tttsss", (new Date()).getTime());


		//
		// from http://stackoverflow.com/a/5112734
		//

		var deferred = new $.Deferred();
		var promise = deferred.promise();

		var jqxhr = $.ajax({
			type: method,
			url: url,
			data: postData,
			dataType: "json",
			cache: "false"
		});

		jqxhr.fail($.proxy(function(thexhr, useless, httpstatustext) {
			if (thexhr.status == 404) {
				alert("Page not found");
			}

			deferred.reject(null);
		}, this));


		jqxhr.done($.proxy(function(responseBody) {

			if (responseBody == null) {
				alert("no response");
				deferred.reject(null);
			}
			
			console.log("response", responseBody);
			
			//
			// all hail the glorius response :)
			//
			deferred.resolve(responseBody);
		}, this));

		return promise;
	}
	
	function addparamtourl(url, key, value) {
		key = escape(key);
		value = escape(value);
		
		var glue = "&";

		//		
		// look for existing query
		//
		if (url.split("?").length == 1) {
			// no existing query
			glue = "?";
		}
		
		return url + glue + key + "=" + value;
	}

})(jQuery);
