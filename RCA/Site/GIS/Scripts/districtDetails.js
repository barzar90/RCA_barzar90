var map, vectors, select;
function init(id) {
    var defaultStyle = new OpenLayers.Style({ label: "${getLabel}",
        cursor: "pointer",
        'pointRadius': 15,
        fontSize: "11px",
        fontColor: "${getLabelColor}",
        fontFamily: "Calibri",
        title: 'selectedFeature',
        'externalGraphic': "${geticon}",
        labelXOffset: "-10",
        labelYOffset: "-25"
    }, { context: {

        getLabel: function (feature) { return feature.data.FName; },
        getLabelColor: function (feature) {
            var fcolor;
            if (feature.data.Ftype == "Co-Operative" || feature.data.Ftype == "co-operative") {
                fcolor = "#04B404"
            }
            else {
                fcolor = "#CD3200";
            }

            return fcolor;
        },
        geticon: function (feature) {
            var fty = ""
            if (feature.data.Ftype == "Co-Operative" || feature.data.Ftype == "co-operative") {
                fty = "coop_factory.gif";
            }
            else {
                fty = "pvt_factory.gif";
            }
            return "../../img/" + fty;

        }


    }
    });

    var selectStyle = new OpenLayers.Style({ 'pointRadius': 20 });

    options = {
        projection: new OpenLayers.Projection("EPSG:900913"),
        units: "m",
        numZoomLevels: 18,
        maxResolution: 156543.0339,
        maxExtent: new OpenLayers.Bounds(-20037508, -20037508, 20037508, 20037508.34)
    };
    var fromProjection = new OpenLayers.Projection("EPSG:4326");
    var toProjection = new OpenLayers.Projection("EPSG:900913");
    var position = new OpenLayers.LonLat(78.41, 21.52).transform(fromProjection, toProjection);
    var zoom = 5;
    map = new OpenLayers.Map({
        div: "map",
        allOverlays: true,
        projection: new OpenLayers.Projection("EPSG:900913")
    });

    var MapFeature = new OpenLayers.StyleMap(new OpenLayers.Style({ fillColor: "${getColor}",
        fillOpacity: 0.8, strokeColor: "#000000",
        strokeWidth: 1, strokeOpacity: 0.5, strokeDashstyle: "dash",
        label: "${getLabel}",
        fontSize: "11px", fontColor: "#585858"
    },
     { context: { getLabel: function (feature) {
         return feature.data.Name;
     }, getColor: function (feature) {
         return feature.data.Color;
     }
     }

     }));


    var styleMap = new OpenLayers.StyleMap({ 'default': defaultStyle, 'select': selectStyle })

    vectors = new OpenLayers.Layer.Vector("Districts", { styleMap: MapFeature, isBaseLayer: true });
    poivectors = new OpenLayers.Layer.Vector("Districts", { styleMap: styleMap, isBaseLayer: false });
    map.addLayer(vectors);
    map.addLayer(poivectors);
    map.setCenter(position, zoom);
    setvectorlayer(id);
    map.zoomToExtent(vectors.getDataExtent());
    // setpoi(1);
    setpoi(id);



    poivectors.events.on({

        'featureselected': function (feature) {
            onFeatureSelect(feature)
        },
        'featureunselected': function (feature) {
            //alert("Bye");
            onFeatureUnselect(feature.feature)
        }
    });
    //  { clickout: true, toggle: true, hover: true, callbacks: { 'over': onFeatureOver} }
    select = new OpenLayers.Control.SelectFeature(poivectors);
    map.addControl(select);
    select.activate();


}

function onFeatureSelect(feature) {

    selectedFeature = feature.feature;
    var cnt = "";
    cnt += "<div  style='font-size:.8em; height:auto;'><table style='background-color:" + vectors.features[0].data.Color + ";' class='CSSTableGenerator'><tr><td colspan='2' style='font-size:14px;font-weight:bold; text-align:center'>Factory Information </td></tr><tr><td><table  >";

    // +"<tr><td>Factory ID: " + feature.feature.data.FID + "</td></tr><tr><td>Factory Name: " + feature.feature.data.FName + "</td></tr><tr><td><a  class='iframe' href='Factory_Details.aspx?id=" + feature.feature.data.FID + "' >Details</a></td></tr>;

    var poiinfo = districtDetails.GetpoiInfo(feature.feature.data.FID);
    if (poiinfo.value.Tables[0].Rows.length > 0) {
        if (poiinfo.value != null) {

            for (key in poiinfo.value.Tables[0].Rows[0]) {
                if (key == "FactoryInfo") {

                    var path1 = poiinfo.value.Tables[0].Rows[0].FactoryInfo;

                    if (path1 != null) {
                        if (path1 != '') {

                            cnt += "<tr ><td>Factory Info :</td><td><a style='color: green;' href='../Upload/galleryImages/" + path1 + "' target='_blank'> Get Factory Info</a></td></tr>";
                            //cnt += "<tr ><td>Factory Info :</td><td><a href='../Upload/galleryImages/" + path1 + "' target='_blank'> Get Balance Sheet</a></td></tr>";
                        }
                        else {
                            cnt += "<tr ><td>Factory Info :</td><td><a style='color: red;' href='#' onclick='GetPDF(" + path1 + ")'>Get Factory Info</a></td></tr>";
                        }
                    }
                    else {
                        cnt += "<tr ><td>Factory Info :</td><td><a style='color: red;' href='#' onclick='GetPDF(" + path1 + ")'>Get Factory Info</a></td></tr>";
                    }


                }

                else {
                    cnt += "<tr><td>" + key + " :</td><td>" + poiinfo.value.Tables[0].Rows[0][key] + "</td></tr>";
                }

            }
            cnt += "</table></td><td><table style='background-color:" + vectors.features[0].data.Color + ";'>";
            for (key in poiinfo.value.Tables[1].Rows[0]) {

                //                 if (key = "Factory_Info_File") {

                //                     cnt += "<tr ><td>" + key + " :</td><td><a herf='/" + poiinfo.value.Tables[0].Rows[0][key] + "'></a></td></tr>";

                //                 }
                //                 else if (key = "AuditReports") {
                //                     cnt += "<tr ><td>" + key + " :</td><td><a herf='/" + poiinfo.value.Tables[0].Rows[0][key] + "'></a></td></tr>";
                //                 }
                //                 else {
                if (key == "BalanceSheet") {
                    var path1 = poiinfo.value.Tables[2].Rows[0].AuditReports;

                    if (path1 != null) {
                        if (path1 != '') {
                            cnt += "<tr ><td>Balance Sheet :</td><td><a style='color: green;' href='../Upload/galleryImages/" + path1 + "' target='_blank'> Get Balance Sheet</a></td></tr>";
                        }
                        else {
                            if (poiinfo.value.Tables[1].Rows[0]["Factory Type"] == "Private") {
                                //  cnt += "<tr ><td>" + key + " :</td><td>" + poiinfo.value.Tables[1].Rows[0][key] + "</td></tr>";
                                cnt += "<tr ><td>" + key + " :</td><td><a >Not Applicable</a></td></tr>";
                            }
                            else {

                                // cnt += "<tr ><td>" + key + " :</td><td>" + poiinfo.value.Tables[1].Rows[0][key] + "</td></tr>";
                                cnt += "<tr ><td>" + key + " :</td><td><a style='color: red;' href='#' onclick='GetAuditReports(" + path1 + ")'> Get Balance Sheet</a></td></tr>";
                            }
                        }
                    }
                    else {
                        cnt += "<tr ><td>" + key + " :</td><td>" + poiinfo.value.Tables[1].Rows[0][key] + "</td></tr>";
                        cnt += "<tr ><td>" + key + " :</td><td><a style='color: red;' href='#' onclick='GetAuditReports(" + path1 + ")'> Get Balance Sheet</a></td></tr>";
                    }

                }

                else {
                    if (key == "Audit Category") {
                        if (poiinfo.value.Tables[1].Rows[0]["Factory Type"] == "Private") {
                            cnt += "<tr ><td>" + key + " :</td><td>Not Applicable</td></tr>";
                        }
                        else {
                            if (poiinfo.value.Tables[1].Rows[0]["Audit Category"] == null) {
                                cnt += "<tr ><td>" + key + " :</td><td>Updating soon</td></tr>";
                            }
                            else {
                                cnt += "<tr ><td>" + key + " :</td><td>" + poiinfo.value.Tables[1].Rows[0][key] + "</td></tr>";
                            }
                        }
                    }
                    else {
                        cnt += "<tr ><td>" + key + " :</td><td>" + poiinfo.value.Tables[1].Rows[0][key] + "</td></tr>";
                    }
                }


            }

            cnt += "</table></td></tr>";

            cnt += "<tr><td colspan='2'><center><img src='../Upload/galleryImages/" + poiinfo.value.Tables[2].Rows[0].Factory_Image + "' alt='' width='100%'> </center></td></tr></table></div>";
        }
    }


    popup = new OpenLayers.Popup.FramedCloud("chicken",
            feature.feature.geometry.getBounds().getCenterLonLat(),
            null, cnt,
            null, true, onPopupClose);


    feature.feature.popup = popup;


    //     map.addPopup(popup);
    //     var popup_point = new OpenLayers.LonLat(feature.feature.geometry.x, feature.feature.geometry.y);
    //     var anchor = { 'size': new OpenLayers.Size(0, 0), 'offset': new OpenLayers.Pixel(-10, -10) };

    //     popup = new OpenLayers.Popup.Anchored("fence",
    //                       popup_point,
    //                       new OpenLayers.Size(400, 200),
    //                       cnt,
    //                       anchor,
    //                       false, onPopupClose);
    //        
    //      popup.autoSize = true;
    map.addPopup(popup);

};



function onFeatureOver(feature) {
    selectedFeature = feature.feature;

    var cnt = "<div  style='font-size:.8em; height:auto;'><table><tr><td>Factory ID: " + feature.feature.data.FID + "</td></tr><tr><td>Factory Name: " + feature.feature.data.FName + "</td></tr><tr><td><a  class='iframe' href='Factory_Details.aspx?id=" + feature.feature.data.FID + "' >Details</a></td></tr></table></div>";

    //     popup = new OpenLayers.Popup.FramedCloud("chicken",
    //            feature.feature.geometry.getBounds().getCenterLonLat(),
    //            null, cnt,
    //            null, false, onPopupClose);
    //     feature.feature.popup = popup;
    //     map.addPopup(popup);

    var popup_point = new OpenLayers.LonLat(feature.feature.geometry.x, feature.feature.geometry.y);
    var anchor = { 'size': new OpenLayers.Size(0, 0), 'offset': new OpenLayers.Pixel(-10, -10) };

    popup = new OpenLayers.Popup.Anchored("fence",
                       popup_point,
                       null,
                       cnt,
                       anchor,
                       false, onPopupClose);

    popup.autoSize = true;
    map.addPopup(popup);

};

function onFeatureout(feature) {
    map.removePopup(map.popups[0]);
    map.popup = null;
};
// function onFeatureUnselect(feature) {
//     map.removePopup(feature.popup);
//     feature.popup.destroy();
//     feature.popup = null;
// };
function onFeatureUnselect(feature) {
    map.removePopup(map.popups[0]);
    map.popup = null;
};
function onPopupClose(evt) {
    select.unselect(selectedFeature);
};



function GetPDF(path) {
    if (path == undefined) {
        alert('Factory info not found');
    }
    else {

        window.open("../Upload/galleryImages/" + path);

    }
}

function GetAuditReports(path1) {
    if (path1 == null) {
        alert('Balance sheet not found');
    }
    else {

        window.open("../Upload/galleryImages/" + path1);

    }
}

 function onSucess(result) 
 {
                alert("ok");
            }
function onError(result) 
 {
                alert("ok");
            }

           




 function setvectorlayer(dist) {


    vectors.removeAllFeatures();

    var polygons = MOLGIS.GetDistricts(dist);
    if (polygons.value.Tables[0].Rows.length > 0) {
        if (polygons.value != null) {
            for (var i = 0; i < polygons.value.Tables[0].Rows.length; i++) {
                var in_options = {
                    'internalProjection': new OpenLayers.Projection("EPSG:900913"),
                    'externalProjection': new OpenLayers.Projection("EPSG:4326")
                };
                var wkt_mod = new OpenLayers.Format.WKT(in_options);
                poly = polygons.value.Tables[0].Rows[i].SHAPE;
                var st_mod = wkt_mod.read(poly);
                //var gid = polygons.value.Tables[0].Rows[0].GID;
                var name = polygons.value.Tables[0].Rows[i].name;
                var color = polygons.value.Tables[0].Rows[i].color;
                st_mod.data = { Name: name, Color: color }
                vectors.addFeatures(st_mod);
                //  map.zoomToExtent(vectors.getDataExtent());
                //   setpoi(dist);
            }
        }
    }
}

function setpoi(dist) 
{

    poivectors.removeAllFeatures();
    var polygons = districtDetails.Getpoi(dist);
    if (polygons.value.Tables[0].Rows.length > 0)
     {
        if (polygons.value != null) 
        {
            for (var i = 0; i < polygons.value.Tables[0].Rows.length; i++) 
            {
                var in_options = 
                {
                    'internalProjection': new OpenLayers.Projection("EPSG:900913"),
                    'externalProjection': new OpenLayers.Projection("EPSG:4326")
                };
                var wkt_mod = new OpenLayers.Format.WKT(in_options);
                poly = polygons.value.Tables[0].Rows[i].SHAPE;
                var st_mod = wkt_mod.read(poly);
                var name = polygons.value.Tables[0].Rows[i].NAME;
                var fid = polygons.value.Tables[0].Rows[i].FID;
                var Facttype = districtDetails.GetFtype(polygons.value.Tables[0].Rows[i].FID);
                st_mod.data = { FID: fid, FName: name, Ftype: Facttype.value 
                }
                poivectors.addFeatures(st_mod);
            }
        }
    }
}

function printDiv(divName) 
{
    var printContents = document.getElementById(divName).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}
