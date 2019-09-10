function initMap() {
    var Minsk = { lat: 53.8978071, lng: 27.5544037 };
    var Store = { lat: 53.8845255, lng: 27.4489082 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 11,
        center: Minsk
    });
    var marker = new google.maps.Marker({
        position: Store,
        map: map,
        title: 'Магазин находится не здесь'
    });

    var about = '<b>Наш магазин комиксов</b><div><img src="https://upload.wikimedia.org/wikipedia/ru/thumb/6/67/Dungeon.gif/220px-Dungeon.gif" height="80px"/></div><p>Время работы: Без выходных с 12:00 до 20:00 </p><p>Адрес: Улица Неизвестная 25 г.Минск</p><p>Метро: Каменная горка </p><p>Транспорт: Автобус, Тролейбус</p></div>'
    var infowindow = new google.maps.InfoWindow({
        content: about
    });
    marker.addListener('click', function () {
        infowindow.open(map, marker);
    });
}