///////////////////////////////////////////////////////////////////////////////
//
//   (c) MahaOnline Limited  2013.  All rights reserved.
//
// 
///////////////////////////////////////////////////////////////////////////////

var map, Extent;

function init() {

    var defaultStyle = new OpenLayers.Style({
        'pointRadius': 40,
        'externalGraphic': "Images/factoryIcon.png"

    });

    var selectStyle = new OpenLayers.Style({ 'pointRadius': 13 });

    map = new OpenLayers.Map('map');
    map.addControl(new OpenLayers.Control.LayerSwitcher());
    map.addControl(new OpenLayers.Control.MousePosition());

    matrix = new OpenLayers.Layer.WMS("Mahaonline", "http://gis.mahaonline.gov.in:9090/geoserver/Mahaonline/wms",
                    {
                        LAYERS: 'Mahaonline:MahaDist',
                        format: 'image/png',
                        transparent: 'true',
                        tilesOrigin: map.maxExtent.left + ',' + map.maxExtent.bottom
                    },
                    { singleTile: false, buffer: 0, displayOutsideMaxExtent: false, isBaseLayer: true }
                );
      map.addLayers([matrix]);

      MahaSugar = new OpenLayers.Layer.WMS("Factory Villages", "http://gis.mahaonline.gov.in:9090/geoserver/Mahaonline/wms",
                    {
                        LAYERS: 'Mahaonline:SugarVillagesGIS',
                        format: 'image/png',
                        transparent: 'true',
                        tilesOrigin: map.maxExtent.left + ',' + map.maxExtent.bottom
                    },
                    { singleTile: true, buffer: 0, displayOutsideMaxExtent: true, isBaseLayer: false, 'reproject': true }
                );
                    MahaSugar.mergeNewParams({ cql_filter: "District='0'" });
                    map.addLayers([MahaSugar]);
//      MahaSugarPOI = new OpenLayers.Layer.WMS("Factory Villages", "http://localhost:9090/geoserver/Mahaonline/wms",
//                    {
//                        LAYERS: 'Mahaonline:FactoryPOI',
//                        format: 'image/png',
//                        transparent: 'true',
//                        tilesOrigin: map.maxExtent.left + ',' + map.maxExtent.bottom
//                    },
//                    { singleTile: true, buffer: 0, displayOutsideMaxExtent: true, isBaseLayer: false, 'reproject': true }
//                );
//      
//      map.addLayers([MahaSugarPOI]);
                    //styleMap: new OpenLayers.StyleMap({ 'default': defaultStyle, 'select': selectStyle }),
      poivectors = new OpenLayers.Layer.Vector("Factory Location", {styleMap: new OpenLayers.StyleMap({ 'default': defaultStyle, 'select': selectStyle }), isBaseLayer: false });
                    
                    map.addLayer(poivectors);

                    map.setCenter(new OpenLayers.LonLat(76.105082, 19.028889), 7);
                }
function Clearemap() {
    poivectors.removeAllFeatures();
    MahaSugar.mergeNewParams({ cql_filter: "District='0'" });
           
    }

 function setcmap() 
{

    var District = document.getElementById('ContentPlaceHolder1_ddlDistrict').value;
    var SubDist = document.getElementById('ContentPlaceHolder1_ddlSubDist').value;
    var Factory = document.getElementById('ContentPlaceHolder1_ddlFactory').value;
    poly = FactoryMap.GetExtentDispensory(District, SubDist, Factory);
    polystr = poly = poly.value.Tables[0].Rows[0].SHAPE;
    var wkt_mod = new OpenLayers.Format.WKT();
    var st_mod = wkt_mod.read(poly);
    map.zoomToExtent(st_mod.geometry.getBounds());

    // var QryStr = "District='" + District + "' and SubDistrict='" + SubDist + "' and Dispensory='" + Dispensory + "' and VillageName='" + Village + "'";
    var QryStr = "District='" + District + "' and SubDistrict='" + SubDist + "' and F1='" + Factory + "'";
    MahaSugar.mergeNewParams({ cql_filter: QryStr });
    setpoi(District, SubDist, Factory);
}

function setpoi(Dist, SubDi, Fact) {
    poivectors.removeAllFeatures();
    var point = FactoryMap.GetPoint(Dist, SubDi, Fact);
    if (point.value.Tables[0].Rows.length > 0) {
        if (point.value != null) {
                var wkt_mod = new OpenLayers.Format.WKT();
                po = point.value.Tables[0].Rows[0].SHAPE;
                var st_mod = wkt_mod.read(po);
                var FName = point.value.Tables[0].Rows[0].FactoryName;
                st_mod.data = {'Factory Name': FName}
                poivectors.addFeatures(st_mod);
        }
    }
}