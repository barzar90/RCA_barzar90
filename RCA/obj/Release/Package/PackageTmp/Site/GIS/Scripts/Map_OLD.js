var map;
function init() 
{
    
    var bounds = new OpenLayers.Bounds(72.64979, 15.60618,80.89912, 22.02903 );

    var fromProjection = new OpenLayers.Projection("EPSG:4326");
    var toProjection = new OpenLayers.Projection("EPSG:900913");
    var zoom = 6;
    var options = { theme: null,
        projection: new OpenLayers.Projection("EPSG:900913"),
        displayProjection: new OpenLayers.Projection("EPSG:4326"),
        units: "m",
        numZoomLevels: 14,
        minZoomLevel: 8,
        maxZoomLevel: 14,
        maxResolution: 156543.0339,
        maxExtent: new OpenLayers.Bounds(-20037508.34, -20037508.34, 20037508.34, 20037508.34)
    };
    map = new OpenLayers.Map('map', options);


    ////////////////////////////////////////////---------------WMST--------------------////////////////////////////////////////
        var matrixIds = new Array(20);
        for (var i = 0; i < 14; ++i) {
            matrixIds[i] = "EPSG:900913:" + i;
        }
        var wmts = new OpenLayers.Layer.WMTS({
            name: "Mahaonline",
            url: "http://gis.mahaonline.gov.in:9090/geoserver/gwc/service/wmts",
            layer: "Mahaonline:MahaDist",
            matrixSet: "EPSG:900913",
            matrixIds: matrixIds,
            format: "image/png",
            style: "_null",
            isBaseLayer: true
        });

       map.addLayers([wmts]);
    ////////////////////////////////////////////---------------WMS--------------------////////////////////////////////////////


//    wmsMaharashtra = new OpenLayers.Layer.WMS("Mahaonline", "http://172.16.1.148:9090/geoserver/Mahaonline/wms",
//                    {
//                       // EXCEPTIONS: 'application / vnd.ogc.se_xml',
//                        LAYERS: 'Mahaonline:Maharashtra',
//                        format: 'image/png',
//                        transparent: 'true',
//                        style: null,
//                        tilesOrigin: map.maxExtent.left + ',' + map.maxExtent.bottom
//                    },
//                    { singleTile: true, buffer: 0, displayOutsideMaxExtent: true, isBaseLayer: false, 'reproject': true }
//                );
//    map.addLayers(wmsMaharashtra);
    //wmsMaharashtra.mergeNewParams({ SLD: 'http://172.16.1.148:9090/geoserver/rest/styles/NewSLD.sld' })

    var in_options = {
        'internalProjection': new OpenLayers.Projection("EPSG:900913"),
        'externalProjection': new OpenLayers.Projection("EPSG:4326")
    };

    var wkt_mod = new OpenLayers.Format.WKT(in_options);
    st_mod = wkt_mod.read(bounds.toGeometry().toString());
    map.zoomToExtent(st_mod.geometry.getBounds());


    map.events.register("zoomend", map, function (e) {

        if (map.getZoom() <= 6) {
            if (map.getZoom() >= 6) {
                return false;
            }
            else {
                map.zoomToExtent(st_mod.geometry.getBounds());
            }
        }
        else {

        }

    });

}











