
window.onloadstart = function () {
    var popup;
    var n = 1;
    var options = {
        zoom: 3
        , center: new google.maps.LatLng(18.2, -66.5)
        , mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById('map'), options);
    var limits = new google.maps.LatLngBounds();

    var place = new Array();
    place['San Juan'] = new google.maps.LatLng(18.465, -66.105);
    place['Fajardo'] = new google.maps.LatLng(18.336, -65.65);
    place['Culebras'] = new google.maps.LatLng(18.315, -65.3);
    place['Vieques'] = new google.maps.LatLng(18.125, -65.44);
    place['Humacao'] = new google.maps.LatLng(18.14, -65.88);
    place['Ponce'] = new google.maps.LatLng(18.025, -66.615);
    place['Mayagüez'] = new google.maps.LatLng(18.215, -67.14);

    for (var i in place) {
        var marker = new google.maps.Marker({
            position: place[i]
            , map: map
            , title: i
            , icon: 'http://www.iconsdb.com/icons/preview/tropical-blue/map-marker-2-xl.png'
        });

        google.maps.event.addListener(marker, 'mouseover', function () {
            this.setIcon('http://gmaps-samples.googlecode.com/svn/trunk/markers/green/blank.png');
        });

        google.maps.event.addListener(marker, 'mouseout', function () {
            this.setIcon('http://gmaps-samples.googlecode.com/svn/trunk/markers/blue/blank.png');
        });

        google.maps.event.addListener(marker, 'mousedown', function () {
            this.setIcon('http://gmaps-samples.googlecode.com/svn/trunk/markers/red/blank.png');
        });

        google.maps.event.addListener(marker, 'mouseup', function () {
            this.setIcon('http://gmaps-samples.googlecode.com/svn/trunk/markers/green/blank.png');
        });

        limits.extend(place[i]);
    }
    map.fitBounds(limits);
};