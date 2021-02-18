Доброго времени суток!
К сожалению, не получилось полностью выполнить задание - не хватило времени.

Инструкция:
1) раскомитить строчку 18 в файле Program.cs. Эта строчка создаёт базу данных. В последующих запусках эту строчку рекомендуется удалить.
2) Нажать F5 - дальше следовать указаниям.

Касательно заданий.
1) "Приложение, которое позволяет скачивать произвольную HTML-страницу посредством HTTP-запроса на жесткий диск компьютера" 
https://github.com/Heavy32/SimbirSoftTestTask/blob/master/Services/HtmlPageDownloader.cs
Пример применения данного класса находится в файле Program.cs строчка 70 метод Download

2) "...и выдает статистику по количеству уникальных слов в консоль."
Сначала из странички извлекаются слова
https://github.com/Heavy32/SimbirSoftTestTask/blob/master/Services/HtmlPageToStringConverter.cs
а потом происходит фильтрация с помощью декоратора
https://github.com/Heavy32/SimbirSoftTestTask/tree/master/Services/FilterDecorator
а затем собирается всё в статистику
https://github.com/Heavy32/SimbirSoftTestTask/blob/master/Services/StatisticProvider.cs

Пример применения данного класса находится в файле Program.cs строчка метод GetStatisticAndSaveToDbAsync
Здесь же дополнительно реализована запись в базу данных

3) "Приложение должно предусматривать возможность нештатных ситуаций и
обеспечивать обработку исключений"
для этого в каждом классе происходят дополнительные проверки с записью в логгер.

4) "Использование паттернов проектирования"
Декоратор https://github.com/Heavy32/SimbirSoftTestTask/tree/master/Services/FilterDecorator
Синглтон https://github.com/Heavy32/SimbirSoftTestTask/blob/master/Services/LoggerSingleton.cs

5) "Логирование ошибок в файл"
https://github.com/Heavy32/SimbirSoftTestTask/blob/master/Services/LoggerSingleton.cs

6) "Сохранение статистики в базу данных."
в слое бизнес-логике
https://github.com/Heavy32/SimbirSoftTestTask/blob/master/Services/SaveStatisticToDataBase.cs
в слое базы данных
https://github.com/Heavy32/SimbirSoftTestTask/blob/master/DataBaseProvider/StatisticRepository.cs
База данных не нормализирована, а так же есть проблема - статистика с одного и того же сайта может записываться много раз, что неприемлимо. В будущем - нужно сделать проверку, есть ли записи с данного сайта или нет.

7) "Возможность расширяемости проекта и многоуровневую архитектуру"
Попытка трёхслойной архитектуры. Есть нарушения, но они сделаны для более удобного пользования. В боевых ситуациях слой представления не должен иметь зависимость от слоя базы данных.

Благодарю за возможность поучаствовать в отборе.
Со мной можно связаться
1) по почте: maksim.gorankov@gmail.com
2) телеграм (он же и телефон): 89526592232
3) вк: https://vk.com/id48708350

