# ReceiptOrders

## Задание:

Необходимо разработать приложение на c# для поддержания структуры БД для хранения приходных ордеров. 
Необходимо учесть хранение основных атрибутов документа таких как: № документа, дата, договор поставки, 
поставщик, место хранения приходуемых единиц товаров. Также в приходном документе необходимо хранить единицы 
приходуемых товаров с указанием номенклатурного номера, количества, цены и стоимости товара. Особое внимание
необходимо уделить поддержке целостности данных.

### Реализация:

В приложении представлено три основных страницы: список приходных ордеров, который включает в себя сам документ и входящие в него товары, список товаров и список показыающий какие товары содержаться в документах

На первой страницы есть возможность добавить новый документ и изменить и удалить уже существующий.

На второй странице можно добавить новый товар и отредактировать или удалить уже существующий. 

На третьей странице можно добавить в документ существующий товар и указать его количество. Также можно убрать товары из документов или отредактировать существующие связи между документами и товарами.
