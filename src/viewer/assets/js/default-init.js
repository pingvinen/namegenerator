(function($, undefined) {

	var $prevBtn = $('#pagination').find('#prev');
	var $nextBtn = $('#pagination').find('#next');

	$(document).bind('keyup', 'left', function(){ $prevBtn.get(0).click() });
	$(document).bind('keyup', 'right', function(){ $nextBtn.get(0).click() });

})(jQuery);