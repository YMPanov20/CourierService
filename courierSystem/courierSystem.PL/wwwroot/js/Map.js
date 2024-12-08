var map = L.map('map', {
    minZoom: 7,
    attributionControl: false
}).setView([42.7339, 25.4858], 7);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 18
}).addTo(map);

var resetButton = L.control({ position: 'bottomleft' });

resetButton.onAdd = function () {
    var div = L.DomUtil.create('div', 'leaflet-bar leaflet-control leaflet-control-custom');
    div.innerHTML = '<a href="#" title="Reset Map View" role="button" onclick="resetMap()">&#x25c0;</a>';
    return div;
};

resetButton.addTo(map);

function resetMap() {
    map.setView([42.7339, 25.4858], 7);
}

var southWest = L.latLng(41.2355, 22.3578);
var northEast = L.latLng(44.2142, 28.8879);
var bounds = L.latLngBounds(southWest, northEast);
map.setMaxBounds(bounds);
map.on('drag', function () {
    map.panInsideBounds(bounds, { animate: false });
});

var cityMarkers = {
    "Burgas": L.marker([42.5048, 27.4626]),
    "Varna": L.marker([43.2047, 27.9116]),
    "Veliko Tarnovo": L.marker([43.0757, 25.6172]),
    "Plovdiv": L.marker([42.1354, 24.7453]),
    "Sofia": L.marker([42.6977, 23.3219])
};

var additionalMarkers = [];

function addAddressesToMapSofia() {
    var addresses = {
        "Sofia Lulin": L.marker([42.7152, 23.2607]),
        "Sofia Center 1": L.marker([42.7004, 23.3238]),
        "Sofia Center 2": L.marker([42.6983, 23.3343])
    };

    Object.keys(addresses).forEach(key => {
        addresses[key].addTo(map).bindPopup(key);
        additionalMarkers.push(addresses[key]);
    });

    map.removeLayer(cityMarkers["Sofia"]);
}

function addAddressesToMapBurgas() {
    var addresses = {
        "Address 1": L.marker([42.4959, 27.4811]),
        "Address 2": L.marker([42.5134, 27.4694]),
        "Address 3": L.marker([42.5208, 27.4950])
    };

    Object.keys(addresses).forEach(key => {
        addresses[key].addTo(map).bindPopup(key);
        additionalMarkers.push(addresses[key]);
    });

    map.removeLayer(cityMarkers["Burgas"]);
}

function addAddressesToMapVarna() {
    var addresses = {
        "Address 1": L.marker([43.2065, 27.9167]),
        "Address 2": L.marker([43.2119, 27.9191]),
        "Address 3": L.marker([43.2163, 27.9222])
    };

    Object.keys(addresses).forEach(key => {
        addresses[key].addTo(map).bindPopup(key);
        additionalMarkers.push(addresses[key]);
    });

    map.removeLayer(cityMarkers["Varna"]);
}

function addAddressesToMapPlovdiv() {
    var addresses = {
        "Address 1": L.marker([42.1525, 24.7541]),
        "Address 2": L.marker([42.1402, 24.7610]),
        "Address 3": L.marker([42.1328, 24.7463])
    };

    Object.keys(addresses).forEach(key => {
        addresses[key].addTo(map).bindPopup(key);
        additionalMarkers.push(addresses[key]);
    });

    map.removeLayer(cityMarkers["Plovdiv"]);
}

function addAddressesToMapVelikoTarnovo() {
    var addresses = {
        "Address 1": L.marker([43.0861, 25.6415]),
        "Address 2": L.marker([43.0778, 25.6507]),
        "Address 3": L.marker([43.0656, 25.6428])
    };

    Object.keys(addresses).forEach(key => {
        addresses[key].addTo(map).bindPopup(key);
        additionalMarkers.push(addresses[key]);
    });

    map.removeLayer(cityMarkers["Veliko Tarnovo"]);
}

function addCityMarkersToMap() {
    Object.keys(cityMarkers).forEach(key => {
        cityMarkers[key].addTo(map).bindPopup(key + " - Courier Office");
    });

    additionalMarkers.forEach(marker => {
        map.removeLayer(marker);
    });
    additionalMarkers = [];
}

map.on('zoomend', function () {
    var zoomLevel = map.getZoom();

    if (zoomLevel > 10) {
        switch (currentCity) {
            case 'Sofia':
                addAddressesToMapSofia();
                break;
            case 'Burgas':
                addAddressesToMapBurgas();
                break;
            case 'Varna':
                addAddressesToMapVarna();
                break;
            case 'Plovdiv':
                addAddressesToMapPlovdiv();
                break;
            case 'Veliko Tarnovo':
                addAddressesToMapVelikoTarnovo();
                break;
        }
    } else {
        addCityMarkersToMap();
    }
});

Object.keys(cityMarkers).forEach(city => {
    cityMarkers[city].on('click', function () {
        var coordinates = cityMarkers[city].getLatLng();
        map.flyTo(coordinates, 11, {
            duration: 1
        });
        currentCity = city;
    });
});

addCityMarkersToMap();