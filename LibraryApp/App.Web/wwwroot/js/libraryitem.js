(function($) {
	var LibraryItemSearchSubmit = function(ev) {
		
		ev.preventDefault();// Prevent launching the default action
		
		var $form = $(this);// Grab the reference to the form
		
		var options = {
			url: $form.attr('action'),
			type: $form.attr('method'),
			data: $form.serialize()
		};// Build the options object
		
		$.ajax(options).done(function(data){
			var target = $($form.attr('data-libraryitem-target'));
			target.html(data);
		});
		
		return false;
	};
	
	var LibraryItemFetchPage = function(ev) {
		
		console.log(ev);
		
		ev.preventDefault();// Prevent launching the default action
		
		console.log($(this));
		
		var $anchor = $(this);// Grab the reference to the anchor that user clicked on
		var page = $anchor.attr('href');
		var $form = $($anchor.parent().parent().attr('search-form-traget'));
		var search = $form.serialize();
		
		var options = {
			url: $anchor.attr('action'),
			type: $anchor.attr('method'),
			data: $form.serialize()
		};// Build the options object
		
		$.ajax(options).done(function(data){
			var target = $($form.attr('data-libraryitem-target'));
			target.html(data);
		});
		
		return false;
	};
	
	$('form[data-libraryitem-ajax="true"]').submit(LibraryItemSearchSubmit);// Look for the form witch contains the attribute "data-libraryitem-ajax" if present wire it up and submit
	
	$('.pagination a').on('click', LibraryItemFetchPage);// Register click event on each anchor in the pagination selector
	
	
})(jQuery);