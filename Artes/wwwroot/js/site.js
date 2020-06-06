// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web ~/fe.

// Write your JavaScript code.


$(document).ready(function () {
	$('[data-toggle="tooltip"]').tooltip();
	// Animate select box length
	var searchInput = $(".search-box input");
	var inputGroup = $(".search-box .input-group");
	var boxWidth = inputGroup.width();
	searchInput.focus(function () {
		inputGroup.animate({
			width: "300"
		});
	}).blur(function () {
		inputGroup.animate({
			width: boxWidth
		});
	});
});