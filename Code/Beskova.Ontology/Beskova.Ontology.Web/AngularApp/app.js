(function() {
	"use strict";
	window.angular.module("APP", ["ngMaterial"])
		.config([
			"$mdDateLocaleProvider", function($mdDateLocaleProvider) {
				$mdDateLocaleProvider.firstDayOfWeek = 1;
				$mdDateLocaleProvider.months = [
					"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
				];
				$mdDateLocaleProvider.shortMonths = [
					"Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сен", "Окт", "Нояб", "Дек"
				];
				$mdDateLocaleProvider.days = ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"];
				$mdDateLocaleProvider.shortDays = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];

				$mdDateLocaleProvider.parseDate = function(string) {
					if (!string) {
						return null;
					}
					var splitted = string.split(".");

					return new Date(splitted[2], +splitted[1] - 1, +splitted[0]);
				};
				$mdDateLocaleProvider.formatDate = function(date) {
					if (!date) {
						return "";
					}

					return date.toLocaleDateString("ru-RU");
				};
				$mdDateLocaleProvider.msgCalendar = "Календарь";
				$mdDateLocaleProvider.msgOpenCalendar = "Открыть календарь";
			}
		])
		.run(function() {
		});;
}());