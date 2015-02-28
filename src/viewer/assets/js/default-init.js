(function($, undefined) {

/*
	function getNames(offset) {
		var deferred = new $.Deferred();
		var promise = deferred.promise();

		var jqxhr = $.ajax({
			type: 'get',
			url: '/names?limit=100&offset='+offset,
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
				alert('No response');
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

	*/








})(jQuery);