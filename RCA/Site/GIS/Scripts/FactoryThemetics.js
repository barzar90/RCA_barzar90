///////////////////////////////////////////////////////////////////////////////
//
//   (c) MahaOnline Limited  2013.  All rights reserved.
//
//
///////////////////////////////////////////////////////////////////////////////


var map, Extent,poivectors;

        var defaultStyle = new OpenLayers.Style({ label: "",
            cursor: "pointer",
            'pointRadius': 10,
            fontSize: "11px",
            fontColor: "${getLabelColor}",
            fontFamily: "Calibri",
            title: "${getLabel}",
            'externalGraphic': "${geticon}",
            labelXOffset: "-10",
            labelYOffset: "-25"
        }, { context: {

            getLabel: function (feature) {
                //        if (map.getZoom() > 10) {
                return feature.attributes.FName;
                //        }
                //        else {
                //            return "";
                //        }
            },

            getLabelColor: function (feature) {
                var fcolor = "blue";
                return fcolor;
            },
            geticon: function (feature) {
                var fty = "Images/icon.bmp"
                return fty;
            }
        }
    });


    function createLeagend()
    {
            var htmlstr="<table>";
            for(i=0;i <poivectors.styleMap.styles['default'].rules.length; i++)
            {
            
            var val=poivectors.styleMap.styles['default'].rules[i].filter.value;
            var typ=poivectors.styleMap.styles['default'].rules[i].filter.type;
            var fild=poivectors.styleMap.styles['default'].rules[0].filter.property;
            var colr=poivectors.styleMap.styles['default'].rules[i].symbolizer.fillColor;
            
            var lval=poivectors.styleMap.styles['default'].rules[1].filter.lowerBoundary;
            var uval=poivectors.styleMap.styles['default'].rules[1].filter.upperBoundary;

            if(val!=null)
                {
                
                    htmlstr+="<tr><td>"+fild+": </td><td>"+val+" </td><td>"+typ+"</td><td style='background-color:"+ colr+";width:20px; '></td></tr>";
                }
                else
                {
                    htmlstr+="<tr><td>"+fild+": </td><td>"+lval+" to "+uval+" </td><td>"+typ+"</td><td style='background-color:"+ colr+";width:20px; '></td></tr>";
                }

            }
            htmlstr+="</table>";
            document.getElementById('LegendDiv').innerHTML=htmlstr;
    }


    function SetStyle(fieldname)
    { 

     if(fieldname=='Capacity')
     {
            var Mstyle = new OpenLayers.Style();
            var ruleLow = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.LESS_THAN,
                  property: fieldname,
                  value: 2500
              }),
              symbolizer: {title: "Lower",pointRadius: 8, fillColor: "green",
                           fillOpacity: 0.5, strokeColor: "black"}
            });
            var ruleMid = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.BETWEEN,
                  property: fieldname,
                  lowerBoundary: 2500,
                  upperBoundary: 5000
              }),
              symbolizer: {title: "Midal",pointRadius: 8, fillColor: "yellow",
                           fillOpacity: 0.5, strokeColor: "black"}
            });
            var ruleHigh = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.GREATER_THAN_OR_EQUAL_TO,
                  property: fieldname,
                  value: 5000,
              }),
              symbolizer: {title: "Higher",pointRadius: 8, fillColor: "red",
                           fillOpacity: 0.7, strokeColor: "black"}
            });
           Mstyle.addRules([ruleLow,ruleMid, ruleHigh]);
           poivectors.styleMap=new OpenLayers.StyleMap({'default': Mstyle });
           poivectors.redraw();
     }
     else if(fieldname=='Recovery')
     {
                    var Mstyle = new OpenLayers.Style();
            var ruleLow = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.LESS_THAN,
                  property: fieldname,
                  value: 10
              }),
              symbolizer: {title: "Lower",pointRadius: 8, fillColor: "green",
                           fillOpacity: 0.5, strokeColor: "black"}
            });
            var ruleMid = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.BETWEEN,
                  property: fieldname,
                  lowerBoundary: 10,
                  upperBoundary: 11.5
              }),
              symbolizer: {title: "Midal",pointRadius: 8, fillColor: "yellow",
                           fillOpacity: 0.5, strokeColor: "black"}
            });
            var ruleHigh = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.GREATER_THAN_OR_EQUAL_TO,
                  property: fieldname,
                  value: 11.5,
              }),
              symbolizer: {title: "Higher",pointRadius: 8,lable:'AAAAAAAAAAAAAAAA', fillColor: "red",
                           fillOpacity: 0.7, strokeColor: "black"}
            });
           Mstyle.addRules([ruleLow,ruleMid, ruleHigh]);
           poivectors.styleMap=new OpenLayers.StyleMap({'default': Mstyle });
           poivectors.redraw();
          
     }
     else
     {
            if(fieldname=='AudicategoryA')
            {
                fieldname='Audicategory Season A'
            }
            else if(fieldname='AudicategoryB')
            {
                fieldname='Audicategory Season B'
            }
            else 
            {
                fieldname='Audicategory Season C'
            }

          var Mstyle = new OpenLayers.Style();
            var ruleLow = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.LESS_THAN,
                  property: fieldname,
                  value: 10
              }),
              symbolizer: {title: "Lower",pointRadius: 8, fillColor: "green",
                           fillOpacity: 0.5, strokeColor: "black"}
            });
            var ruleMid = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.BETWEEN,
                  property: fieldname,
                  lowerBoundary: 10,
                  upperBoundary: 11.5
              }),
              symbolizer: {title: "Midal",pointRadius: 8, fillColor: "yellow",
                           fillOpacity: 0.5, strokeColor: "black"}
            });
            var ruleHigh = new OpenLayers.Rule({
              filter: new OpenLayers.Filter.Comparison({
                  type: OpenLayers.Filter.Comparison.GREATER_THAN_OR_EQUAL_TO,
                  property: fieldname,
                  value: 11.5,
              }),
              symbolizer: {title: "Higher",pointRadius: 8, fillColor: "red",
                           fillOpacity: 0.7, strokeColor: "black"}
            });
           Mstyle.addRules([ruleLow,ruleMid, ruleHigh]);
           poivectors.styleMap=new OpenLayers.StyleMap({'default': Mstyle });
           poivectors.redraw();
     }
      createLeagend();
}





function init(){
    var selectStyle = new OpenLayers.Style({ 'pointRadius': 15 });
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

//    MahaSugar = new OpenLayers.Layer.WMS("Factory Villages", "http://gis.mahaonline.gov.in:9090/geoserver/Mahaonline/wms",
//                    {
//                        LAYERS: 'Mahaonline:SugarVillagesGIS',
//                        format: 'image/png',
//                        transparent: 'true',
//                        tilesOrigin: map.maxExtent.left + ',' + map.maxExtent.bottom
//                    },
//                    { singleTile: true, buffer: 0, displayOutsideMaxExtent: true, isBaseLayer: false, 'reproject': true }
//                );
//    MahaSugar.mergeNewParams({ cql_filter: "District='0'" });
//  map.addLayers([MahaSugar]);

// styleMap: new OpenLayers.StyleMap({ 'default': Mstyle, 'select': selectStyle }),

    poivectors = new OpenLayers.Layer.Vector("Factory Location", { isBaseLayer: false });

    map.addLayer(poivectors);

    map.setCenter(new OpenLayers.LonLat(76.105082, 19.028889), 7);
  //  setpoi();
}

function Clearemap() {
    poivectors.removeAllFeatures();
    MahaSugar.mergeNewParams({ cql_filter: "District='0'" });
}

function setpoi(param1,param2) {
    poivectors.removeAllFeatures();
    var point = FactoryAnalysis.GetPoint(param1);
    if (point.value.Tables[0].Rows.length > 0) {
        if (point.value != null) {
            for (var i = 0; i < point.value.Tables[0].Rows.length; i++) {
                var wkt_mod = new OpenLayers.Format.WKT();
                po = point.value.Tables[0].Rows[i].SHAPE;
                var st_mod = wkt_mod.read(po);
                var FName = point.value.Tables[0].Rows[i].FactoryName;
                var AudicategoryA = point.value.Tables[0].Rows[i]['Audicategory Season A'];
                var AudicategoryB = point.value.Tables[0].Rows[i]['Audicategory Season B'];
                var AudicategoryC = point.value.Tables[0].Rows[i]['Audicategory Season C'];
                var Capacity = point.value.Tables[0].Rows[i].Capacity;
                var Recov = point.value.Tables[0].Rows[i].Recovery;
               // st_mod.data = { 'FName': FName, 'Crushing': Crush, 'Productivity': Prod, 'CurrentRate': Rate, 'Recovery': Recov }
                st_mod.attributes = { 'FName': FName, 'Audicategory Season A': AudicategoryA, 'Audicategory Season B': AudicategoryB, 'Audicategory Season C': AudicategoryC, 'Capacity': Capacity, 'Recovery': Recov };
                poivectors.addFeatures(st_mod);
            }
        }

        SetStyle(param2);
    }
}