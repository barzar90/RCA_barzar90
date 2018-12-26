
var xmlHttpRequest;
function GetData(AppName,FunctionName,ParamID) {
    //create XMLHttpRequest object for -  IE7+, Firefox, Chrome, Opera, Safari (XMLHttpRequest) |for IE6, IE5(Msxml2.XMLHTTP)
    xmlHttpRequest = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Msxml2.XMLHTTP");

    //If the browser doesn't support Ajax, exit now
    if (xmlHttpRequest == null)
        return;

    //Initiate the XMLHttpRequest object
    xmlHttpRequest.open("GET", "AJAXHandler.aspx?AppName=" + AppName + " & FunctionName=" + FunctionName + " & Params=" + ParamID, true);

    //Setup the callback function
    xmlHttpRequest.onreadystatechange = StateChange;

    //Send the Ajax request to the server with the GET data
    xmlHttpRequest.send(null);
}
function StateChange() {
    //0: request not initialized 
    //1: server connection established
    //2: request received 
    //3: processing request 
    //4: request finished and response is ready

    if (xmlHttpRequest.readyState == 4) {

        var data =xmlHttpRequest.responseText;
       // = xDoc.getElementsByTagName("NewDataSet")[0];  
    }
    else 
    {       
        return 'Loading...';
    }
}
//Function to convert string to XML object   

// Changes XML to JSON
function xmlToJson(xml) {
    debugger;
    // Create the return object
    var obj = {};

    if (xml.nodeType == 1) { // element
        // do attributes
        if (xml.attributes.length > 0) {
            obj["@attributes"] = {};
            for (var j = 0; j < xml.attributes.length; j++) {
                var attribute = xml.attributes.item(j);
                obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
            }
        }
    } else if (xml.nodeType == 3) { // text
        obj = xml.nodeValue;
    }

    // do children
    if (xml.hasChildNodes()) {
        for (var i = 0; i < xml.childNodes.length; i++) {
            var item = xml.childNodes.item(i);
            var nodeName = item.nodeName;
            if (typeof (obj[nodeName]) == "undefined") {
                obj[nodeName] = xmlToJson(item);
            } else {
                if (typeof (obj[nodeName].push) == "undefined") {
                    var old = obj[nodeName];
                    obj[nodeName] = [];
                    obj[nodeName].push(old);
                }
                obj[nodeName].push(xmlToJson(item));
            }
        }
    }
    return obj;
};


function StringtoXML(text) {
    if (window.ActiveXObject) {
        var doc = new ActiveXObject('Microsoft.XMLDOM');
        doc.async = 'false';
        doc.loadXML(text);
    } else {
        var parser = new DOMParser();
        var doc = parser.parseFromString(text, 'text/xml');
    }

    return doc;
}
///Function to convert XML to HTML Table
function ConvertToTable(node) {
    debugger;
    var tr, td, i, oneRecord;
    var myDiv = document.createElement('DIV');
    myTable = document.createElement('TABLE');
    myTable.setAttribute("border", 1);
    // node tree
    var data = node.getElementsByTagName("NewDataSet")[0];
    for (i = 0; i < data.childNodes.length; i++) {
        // use only 1st level element nodes to skip 1st level text nodes in NN
        if (data.childNodes[i].nodeType == 1) {
            // one final match record
            oneRecord = data.childNodes[i];
            tr = myTable.insertRow(myTable.rows.length);
            td = tr.insertCell(tr.cells.length);
            td.innerHTML = oneRecord.getElementsByTagName("Name")[0].firstChild.nodeValue;
            td = tr.insertCell(tr.cells.length);
            td.innerHTML = oneRecord.getElementsByTagName("Age")[0].firstChild.nodeValue;
            td = tr.insertCell(tr.cells.length);
            td.innerHTML = oneRecord.getElementsByTagName("Org")[0].firstChild.nodeValue;
        }
    }
    myDiv.appendChild(myTable);
    return myDiv.innerHTML;
}