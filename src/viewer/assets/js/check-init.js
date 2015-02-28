(function($, undefined) {

	$("form").bind('submit', function(event) {
		event.preventDefault();
		return false;
	});

	//
	// contains
	//
	var $containsForm = $("#contains").find("form");
	$containsForm.bind('submit', function() {
		var value = $containsForm.find(":input").val();

		if (value.length > 0) {
			window.ajax('post', '/check/contains', { 'name': value })
				.done(function(response) {
					$("#contains").find(".result").html(response.Message);
				}
			);
		}
	});


	//
	// validation
	//
	var $validateForm = $("#validate").find("form");
	$validateForm.bind('submit', function() {
		var value = $validateForm.find(":input").val();

		if (value.length > 0) {
			window.ajax('post', '/check/validate', { 'name': value })
				.done(function(response) {
					$("#validate").find(".result").html(response.Message);
				}
			);
		}
	});

})(jQuery);