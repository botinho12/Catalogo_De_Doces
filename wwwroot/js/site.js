// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// configuração do dataTable
$(document).ready(function () {
	let table = new DataTable('#table-produtos', {
		language: {
			url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json'
		},
		errorMode: 'none'
	});
});

