﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="ljacts.aspx.cs" Inherits="RCA.Site.Information.ljacts" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- Tablesorter: required -->
	
    <script type="text/javascript" src="../../Scripts/jquery-latest.min.js"></script>
   
    <link class="ui-theme" rel="stylesheet"  href="../../js/css/jquery-ui.min.css" type="text/css"/>
	<script  type="text/javascript" src="../../Scripts/jquery.min.js"></script>
	<%--<link rel="stylesheet" href="../../js/css/jq.css" type="text/css"/>--%>
	 <link rel="stylesheet" href="../../js/css/prettify.css" type="text/css"/> 
	<script  type="text/javascript" src="../../js/prettify.js"></script>
    <script type="text/javascript" src="../../js/docs.js"></script>


    <style type="text/css">
	/* override the vertical-align top in the blue theme */
	.notes.tablesorter-blue tbody td { vertical-align: middle; }
	</style>


   
    <link rel="stylesheet" href="../../Styles/theme.blue.css"/>
	<script type="text/javascript" src="../../js/jquery.tablesorter.js"></script>
	<script  type="text/javascript" src="../../js/jquery.tablesorter.widgets.js"></script>
	<script  type="text/javascript"src="../../Scripts/widgets/widget-filter-type-insideRange.js"></script>
	<script type="text/javascript" src="../../Scripts/parsers/parser-date-range.js"></script>

	<script type="text/javascript" id="js">	    $(function () {
	      
	        // call the tablesorter plugin
	        $("#table").tablesorter({
	            theme: 'blue',
	            widthFixed: true,
	            widgets: ["zebra", "filter"],
	            widgetOptions: {
	                filter_reset: '.reset',
	                // set to false because it is difficult to determine if a filtered
	                // row is already showing when looking at ranges
	                filter_searchFiltered: false
	            }
	        });

	    });
        
        </script>

<script type="text/javascript">
    $(function () {
        
        $('button').on('click', function () {
            var $this = $(this),
			filters = [],
			col = $(this).data('column'),
			query = $(this).text();
            filters[col] = query;
            $('table').trigger('search', [filters]);
        });
    });

</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
  <div class="headingBg">
    <h1>
        <asp:Label ID="lbl_reprint" runat="server"></asp:Label></h1><uc:BreadCrum ID="BreadCrum" runat="server" /></div>

<table id="table" class="table tablesorter tablesorter-blue hasFilters" role="grid"><colgroup class="tablesorter-colgroup"><col style="width: 3.2%;"><col style="width: 3.5%;"><col style="width: 91.2%;"></colgroup>
                <thead style="font-size: larger; font-weight: bold;">
                <tr style="font-weight: bold; background-color: azure;" role="row" class="tablesorter-headerRow">
                        <th data-column="0" class="tablesorter-header tablesorter-headerUnSorted" tabindex="0" scope="col" role="columnheader" aria-disabled="false" aria-controls="table" unselectable="on" aria-sort="none" aria-label="Act No.: No sort applied, activate to apply an ascending sort" style="-webkit-user-select: none;"><div class="tablesorter-header-inner">
                            Act No.
                        </div></th>
                        <th data-column="1" class="tablesorter-header tablesorter-headerUnSorted" tabindex="0" scope="col" role="columnheader" aria-disabled="false" aria-controls="table" unselectable="on" aria-sort="none" aria-label="Act Year: No sort applied, activate to apply an ascending sort" style="-webkit-user-select: none;"><div class="tablesorter-header-inner">
                            Act Year
                        </div></th>
                        <th data-column="2" class="tablesorter-header tablesorter-headerUnSorted" tabindex="0" scope="col" role="columnheader" aria-disabled="false" aria-controls="table" unselectable="on" aria-sort="none" aria-label="Short Title: No sort applied, activate to apply an ascending sort" style="-webkit-user-select: none;"><div class="tablesorter-header-inner">
                            Short Title
                        </div></th>
                    </tr>
                <tr role="row" class="tablesorter-filter-row tablesorter-ignoreRow"><td><input type="search" placeholder="" class="tablesorter-filter" data-column="0" data-lastsearchtime="1464092556037"></td><td><input type="search" placeholder="" class="tablesorter-filter" data-column="1" data-lastsearchtime="1464092556037"></td><td><input type="search" placeholder="" class="tablesorter-filter" data-column="2" data-lastsearchtime="1464092556037"></td></tr></thead>
                <tbody aria-live="polite" aria-relevant="all">
                    <tr role="row" class="odd">
                        <td>
                            40
                        </td>
                        <td>
                            1948
                        </td>
                        <td>
                            <a href="pdf/ljActs/(9) Bom. City Civil Court Act (E) (H 773).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. City Civil Court Act,
                                1948.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            4
                        </td>
                        <td>
                            1932
                        </td>
                        <td>
                            <a href="pdf/ljActs/12-The Bombay Cotton Contract Act-1932.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Cotton Contract, Act 1932.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            68
                        </td>
                        <td>
                            1954
                        </td>
                        <td>
                            <a href="pdf/ljActs/35-The Bombay Ext. of Laws Non-Scheduled..Areas Act-1954.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Extension
                                Of Laws To Non-Scheduled (Partially Excluded) Areas Act, 1954.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            9
                        </td>
                        <td>
                            1939
                        </td>
                        <td>
                            <a href="pdf/ljActs/20-The Bombay Gas Supply Act-1939.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Gas Supply Act, 1939.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            61
                        </td>
                        <td>
                            1959
                        </td>
                        <td>
                            <a href="pdf/ljActs/23-The Bombay Habitual Offenders Act-1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Habitual Offenders
                                Act, 1959.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            8
                        </td>
                        <td>
                            1961
                        </td>
                        <td>
                            <a href="pdf/ljActs/31-The Bombay Municipal Taxes &amp; Urban...Act-1960.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Municipal Taxes and
                                Urban Immovable Property Tax Validation in Certain Areas of the Extended Suburbs
                                of greater Bombay Act, 1960.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            1928
                        </td>
                        <td>
                            <a href="pdf/ljActs/(22) Bom. Non-Agriculturist Loan Act (H 786) .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Non-Agriculturists'
                                Loans Act, 1928.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            5
                        </td>
                        <td>
                            1968
                        </td>
                        <td>
                            <a href="pdf/ljActs/25-The Bombay Queen Victoria Statue Site Act-1968.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Queen Victoria Statue
                                Site (And Adjoining Land Utilization For Construction of Satellite Telecommunications
                                Exchanges of The Overseas Communications Service) Act, 1968.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            22
                        </td>
                        <td>
                            1948
                        </td>
                        <td>
                            <a href="pdf/ljActs/30-The Bombay Refugees Act-1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Refugees Act, 1948.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            Reg. 1
                        </td>
                        <td>
                            1951
                        </td>
                        <td>
                            <a href="pdf/ljActs/36-The Bombay Seals Act..Regulation-1951.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Seals Act (Application
                                To Scheduled Areas) Regulation, 1951</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            22
                        </td>
                        <td>
                            1949
                        </td>
                        <td>
                            <a href="pdf/ljActs/29-The Bombay Seals Act-1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Seals Act, 1948</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            21
                        </td>
                        <td>
                            1960
                        </td>
                        <td>
                            <a href="pdf/ljActs/(26) Bom. Statutory Corporation Act (E) (H 790).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Statutory Corporations
                                (Regional Reorganisation) Act, 1960. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            1966
                        </td>
                        <td>
                            <a href="pdf/ljActs/(23) The Borough Municipalities Act (E) (H 787).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Borough Municipalities
                                (Validation Of Certain Taxes On Buildings And Lands) Act, 1965.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            22
                        </td>
                        <td>
                            1989
                        </td>
                        <td>
                            <a href="pdf/ljActs/(47) Dr. BABASAHEB AMBEDKAR (H 1056).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Dr. Babasaheb Ambedkar Technological University
                                Act, 1989.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                        </td>
                        <td>
                            1960
                        </td>
                        <td>
                            <a href="pdf/ljActs/(73) Maharashtra Adaoation of 1960 (H 4039).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Adaptation of Laws
                                (State And Concurrent Subjects) Order, 1960.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            61
                        </td>
                        <td>
                            1981
                        </td>
                        <td>
                            <a href="pdf/ljActs/(5) Mah. Advocates Welfare Fund (H 769).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Advocates Welfare
                                Fund Act, 1981.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            41
                        </td>
                        <td>
                            1983
                        </td>
                        <td>
                            <a href="pdf/ljActs/(55) The Mah. Agricultural Universities Act, 1983) (H 4055).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Agricultural
                                Universities (Krishi Vidyapeeths) Act, 1983.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            12
                        </td>
                        <td>
                            1961
                        </td>
                        <td>
                            <a href="pdf/ljActs/(7) Mah. Ancient Monuments Archaeological Act (E) (H771).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Ancient
                                Monuments And Archaeological Sites And Remains Act, 1960.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            9
                        </td>
                        <td>
                            1977
                        </td>
                        <td>
                            <a href="pdf/ljActs/(8) Mah. Animal Preservation Act (E) (H 772).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Animal Preservation
                                Act, 1976. </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            6
                        </td>
                        <td>
                            1925
                        </td>
                        <td>
                            <a href="pdf/ljActs/(36) Bombay Beting Tax Act (E) (H 1043).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Betting Tax Act.
                            </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            14
                        </td>
                        <td>
                            1869
                        </td>
                        <td>
                            <a href="pdf/ljActs/(35) Bombay Civil Courts Act (E) (H 1042).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Civil Courts Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            46
                        </td>
                        <td>
                            1956
                        </td>
                        <td>
                            <a href="pdf/ljActs/(10) Mah. Contingency Fund Act (E) (H 774).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Contingency Fund Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            30
                        </td>
                        <td>
                            1999
                        </td>
                        <td>
                            <a href="pdf/ljActs/(6) Mah. Control of Organized Crime Act (E) (H 770).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Control Of Organised
                                Crime Act, 1999.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            24
                        </td>
                        <td>
                            1961
                        </td>
                        <td>
                            <a href="pdf/ljActs/(67) The Mah. Co-operative Societies Act, 1960 (H 4056).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Co-Operative
                                Societies Act, 1960.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            36
                        </td>
                        <td>
                            1959
                        </td>
                        <td>
                            <a href="pdf/ljActs/(45) Bombay Courts Fees Act (E) (H 1053).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Court-Fees Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            3
                        </td>
                        <td>
                            1976
                        </td>
                        <td>
                            <a href="pdf/ljActs/(1) Mah. Debt Relif Act (H 765).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Debt Relief Act, 1975.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            6
                        </td>
                        <td>
                            1918
                        </td>
                        <td>
                            <a href="pdf/ljActs/16-The Maharashtra  Disqualification of Aliens Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Disqualification of
                                Aliens Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            13
                        </td>
                        <td>
                            1976
                        </td>
                        <td>
                            <a href="pdf/ljActs/(4) Mah. Edu. Institutions (Management ) Act (E) (H 768).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Educational
                                Institutions (Management) Act, 1976.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            49
                        </td>
                        <td>
                            1971
                        </td>
                        <td>
                            <a href="pdf/ljActs/(3) Mah. Educational Institutions (Trn) Act (E) (H 767).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Educational
                                Institutions (Transfer Of Management) Act, 1971. </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            40
                        </td>
                        <td>
                            1958
                        </td>
                        <td>
                            <a href="pdf/ljActs/(41) Bom. Electricity Duty Act (E) (H 1049).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Electricity Duty Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            20
                        </td>
                        <td>
                            1978
                        </td>
                        <td>
                            <a href="pdf/ljActs/(61) The Mah. Employment Gaurantee Act, 1977 (H 4021).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Employment Guarantee
                                Act, 1977 .</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            2
                        </td>
                        <td>
                            1868
                        </td>
                        <td>
                            <a href="pdf/ljActs/13-The Maharashtra Ferries &amp; Inland Vessels Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Ferries And Inland
                                Vessels Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            2007
                        </td>
                        <td>
                            <a href="pdf/ljActs/6-The Maha. Fire Prevention &amp; LSM Act-2006.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Fire Prevention and
                                Life Safety Measures Act, 2006.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            22
                        </td>
                        <td>
                            1983
                        </td>
                        <td>
                            <a href="pdf/ljActs/(11) Mah. Forest Development Act (E) (H 775).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Forest Development
                                (Tax On Sale Of Forest-Produce By Government Or Forest Development Corporation)
                                Act, 1983.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            45
                        </td>
                        <td>
                            1969
                        </td>
                        <td>
                            <a href="pdf/ljActs/(18) Mah. Fruit Nurseries Plants Act (E) (H 782).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Fruit Nurseries And
                                Sale Of Fruit Plants (Regulation) Act, 1969.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            2
                        </td>
                        <td>
                            1956
                        </td>
                        <td>
                            <a href="pdf/ljActs/(40) Bom. Government Premises (Eviction) Act (E) (H 1048).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Government
                                Premises (Eviction) Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            27
                        </td>
                        <td>
                            2001
                        </td>
                        <td>
                            <a href="pdf/ljActs/(16) Mah. Gunthewari Development Act (15) (H 780).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Gunthewari Developments
                                (Regulation, Upgradation And Control) Act, 2001.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            3
                        </td>
                        <td>
                            1874
                        </td>
                        <td>
                            <a href="pdf/ljActs/(34) The Bombay Herditary Offices Act (S) (H 798).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Hereditary Offices
                                Act. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            28
                        </td>
                        <td>
                            1977
                        </td>
                        <td>
                            <a href="pdf/ljActs/(51) Mah. Housing And Area Development (H 1060).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Housing And Area Development
                                Act, 1976.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            20
                        </td>
                        <td>
                            1974
                        </td>
                        <td>
                            <a href="pdf/ljActs/27-The Mahara. Increase of Land Rev.&amp;Sp.Asses.Act-1974.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Increase
                                of Land Revenue and Special Assessment Act, 1974.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            45
                        </td>
                        <td>
                            1976
                        </td>
                        <td>
                            <a href="pdf/ljActs/11-The Maha.Keep.&amp;Move. of Cattle in Urban Act-1976.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Keeping
                                And Movement Of Cattle In Urban Areas (Control) Act, 1976.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            40
                        </td>
                        <td>
                            1953
                        </td>
                        <td>
                            <a href="pdf/ljActs/(43) Bom. Labour Welfare Fund Act (E) (H 1051).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Labour Welfare Fund
                                Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            28
                        </td>
                        <td>
                            1942
                        </td>
                        <td>
                            <a href="pdf/ljActs/(39) Bom. Land Improvement Schemes Act (H 1047).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Land Improvement Schemes
                                Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            39
                        </td>
                        <td>
                            1983
                        </td>
                        <td>
                            <a href="pdf/ljActs/(29) The Mah. Land Revenue Code (Amalgamation Act (E) (H 793).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Land
                                Revenue Code (Amalgamation Of Bombay And Konkan Divisions) Act, 1983.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            50
                        </td>
                        <td>
                            1953
                        </td>
                        <td>
                            <a href="pdf/ljActs/(25) Bom. Land Tenures Abolition Record Act (E) (H 789).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Land
                                Tenures Abolition (Recovery Of Records) Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            7
                        </td>
                        <td>
                            1882
                        </td>
                        <td>
                            <a href="pdf/ljActs/(28) Bom. Landing and Wharfage Fees Act (E) (H 792).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Landing And Wharfage
                                Fees Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            47
                        </td>
                        <td>
                            1956
                        </td>
                        <td>
                            <a href="pdf/ljActs/(42) Mah. Legislative Council (Chairman) Assembly (Speaker) Salaries Act (E) (H 1050).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Legislative
                                Council (Chairman And Deputy Chairman) And Maharashtra Legislative Assembly (Speaker
                                And Deputy Speaker) Salaries And Allowances Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            1
                        </td>
                        <td>
                            1977
                        </td>
                        <td>
                            <a href="pdf/ljActs/(38) Mah. Legislative Member Pension Act (E) (H 1045).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Legislature Members'
                                Pension Act, 1976.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            23
                        </td>
                        <td>
                            2005
                        </td>
                        <td>
                            <a href="pdf/ljActs/5-The Maha.Mment of Irri.Sys.byFarmer Act-2005.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Management of Irrigation
                                Systems By Farmers Act, 2005.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            71
                        </td>
                        <td>
                            1953
                        </td>
                        <td>
                            <a href="pdf/ljActs/(24) Bom. Merged Territories Abolition Act (E) (H 788).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Merged Territories
                                (Janjira And Bhor) Khoti Tenure Abolition Act. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            19
                        </td>
                        <td>
                            2001
                        </td>
                        <td>
                            <a href="pdf/ljActs/(12) Mah. Mineral Development Act (H 776) .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Mineral Development
                                (Creation And Utilisation) Fund Act, 2001.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            48
                        </td>
                        <td>
                            1956
                        </td>
                        <td>
                            <a href="pdf/ljActs/(44) Mah. Minister Salaries Allowance Act (E) (H 1052).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Ministers' Salaries
                                And Allowances Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            38
                        </td>
                        <td>
                            1956
                        </td>
                        <td>
                            <a href="pdf/ljActs/9-The Maharashtra Molasses Control Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Molasses (Control) Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            40
                        </td>
                        <td>
                            1965
                        </td>
                        <td>
                            <a href="pdf/ljActs/(54) Mah.  Municipal Counsils No. 992, Panchayats and Industral  Township Act 1915 (H 4061).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Municipal
                                Councils, Nagar Panchayats and Industrial Townships Act, 1965.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            15
                        </td>
                        <td>
                            1949
                        </td>
                        <td>
                            <a href="pdf/ljActs/8-The Maharashtra Nursing Homes Reg. Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Nursing Homes Registration
                                Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            5
                        </td>
                        <td>
                            1965
                        </td>
                        <td>
                            <a href="pdf/ljActs/7-The Maharashtra Official Languages Act-1964.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Official Languages
                                Act,1964.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            46
                        </td>
                        <td>
                            1962
                        </td>
                        <td>
                            <a href="pdf/ljActs/(32) Mah. Police Officers (Change Designation) Act (H 796).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Police
                                Officers (Change In Designation) Act, 1962.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            8
                        </td>
                        <td>
                            1995
                        </td>
                        <td>
                            <a href="pdf/ljActs/3-The Maha.Prevention of Def. Of Property Act-1995.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Prevention of Defacement
                                of Property Act, 1995.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            33
                        </td>
                        <td>
                            1999
                        </td>
                        <td>
                            <a href="pdf/ljActs/(13) Mah. Prohibition of Ragging Act (E) (H 777).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Prohibition Of Ragging
                                Act, 1999.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            29
                        </td>
                        <td>
                            1950
                        </td>
                        <td>
                            <a href="pdf/ljActs/(37) Bombay Public Trusts Act (E) (H 1044).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Public Trusts Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            1
                        </td>
                        <td>
                            1972
                        </td>
                        <td>
                            <a href="pdf/ljActs/(46) Mah. Recognition Trade Union Prevension  Labour Practice Act (E) (H 1054).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Recognition
                                of Trade Unions And Prevention Of Unfair Labour Practices Act, 1971.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            20
                        </td>
                        <td>
                            1999
                        </td>
                        <td>
                            <a href="pdf/ljActs/(20) Mah. Regulation Marriage Bureaus Act (E) (H 784).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Regulation Of Marriage
                                Bureaus And Registration Of Marriages Act, 1998.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            23
                        </td>
                        <td>
                            1963
                        </td>
                        <td>
                            <a href="pdf/ljActs/33-Maharashtra Removal of Dis...Co.-Op.Soci.Act-1963.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Removal Of Disqualifications
                                (Of Holders Of Offices In Co-Operative Societies) Act, 1963.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            8
                        </td>
                        <td>
                            2000
                        </td>
                        <td>
                            <a href="pdf/ljActs/1-Maharashtra Rent Control Act-1999.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Rent Control Act, 1999.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            10
                        </td>
                        <td>
                            1987
                        </td>
                        <td>
                            <a href="pdf/ljActs/(21) Bom. Revenue Jurisdictions Act {A) (H 785).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Revenue Jurisdiction
                                Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            23
                        </td>
                        <td>
                            2001
                        </td>
                        <td>
                            <a href="pdf/ljActs/(14) Mah. Scheduled Castes (Certificate) Act (E) (H 778).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Scheduled
                                Castes, Scheduled Tribes, De-Notified Tribes (Vimukta Jatis), Nomadic Tribes, Other
                                Backward Classes And Special Backward Category (Regulation Of Issuance And Verification
                                Of) Caste Certificate Act, 2000. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            70
                        </td>
                        <td>
                            1953
                        </td>
                        <td>
                            <a href="pdf/ljActs/(50) THE MAHARASHTRA SERVICE INAMS (H 1059).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Service Inams (Useful
                                To Community) Abolition Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            38
                        </td>
                        <td>
                            1997
                        </td>
                        <td>
                            <a href="pdf/ljActs/(48) THE MAHARASHTRA STATE BOARD OF Technical Edu. (H 1057).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. State
                                Board Of Technical Education Act, 1997.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            2
                        </td>
                        <td>
                            2004
                        </td>
                        <td>
                            <a href="pdf/ljActs/4-The Maha.State C. for Occu.&amp;Phyphy Act-2002.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. State Council For
                                Occupational Theraphy And Physiotheraphy Act, 2002.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            1
                        </td>
                        <td>
                            1999
                        </td>
                        <td>
                            <a href="pdf/ljActs/2-Maharashtra State Council Exam.Act-1998.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. State Council Of Examinations
                                Act, 1998.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            8
                        </td>
                        <td>
                            2004
                        </td>
                        <td>
                            <a href="pdf/ljActs/(15) Mah. State Public Services Reservation Act (E) (H 779).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. State
                                Public Services (Reservation For Scheduled Castes, Scheduled Tribes, Denotified
                                Tribes (Vimukta Jatis), Nomadic Tribes, Special Backward Category And Other Backward
                                Classes) Act, 2001.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            16
                        </td>
                        <td>
                            1983
                        </td>
                        <td>
                            <a href="pdf/ljActs/22-The Maharashtra  Suppy of Forest-Produce Act-1982.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Supply of Forest-Produce
                                by Government (Revision of Agreements) Act, 1982.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            29
                        </td>
                        <td>
                            1979
                        </td>
                        <td>
                            <a href="pdf/ljActs/(49) Mah. Tax on Building (with larger  Residential Premises) Act (E) (H 1058).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Tax
                                on Buildings (With Larger Residential Premises) (Re-Enacted) Act, 1979.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            5
                        </td>
                        <td>
                            1960
                        </td>
                        <td>
                            <a href="pdf/ljActs/10-The Maharashtra Warehouses Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Warehouses Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            23
                        </td>
                        <td>
                            1988
                        </td>
                        <td>
                            <a href="pdf/ljActs/(53) The Mah  workmen Minimum House Rent Act (E) 1983 (H 1055).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Workmen's
                                Minimum House-Rent Allowance Act, 1983.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            5
                        </td>
                        <td>
                            2000
                        </td>
                        <td>
                            <a href="pdf/ljActs/(19) Mah. Metropolitan Planning Comm. Act (E) (H 783).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah.Metropolitan Planning
                                Committees (Constitution And Functions) (Continuance Of Provisions) Act, 1999.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            15
                        </td>
                        <td>
                            2004
                        </td>
                        <td>
                            <a href="pdf/ljActs/(17) Rajiv Gandhi Science Technology Act (E) (H 781).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Rajiv Gandhi Science And
                                Technology Commission Act, 2004.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            9
                        </td>
                        <td>
                            1960
                        </td>
                        <td>
                            <a href="pdf/ljActs/34-Repeal &amp; Distribution of Trust Properties Act-1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Sir Currimbhoy
                                Ebrahim Baronetcy (Repeal and Distribution of Trust Properties) Act, 1959</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            45
                        </td>
                        <td>
                            1963
                        </td>
                        <td>
                            <a href="pdf/ljActs/(56) The Administrators GeneralActivities (H 4030).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Administrators-General
                                Act, 1963.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            49
                        </td>
                        <td>
                            1965
                        </td>
                        <td>
                            <a href="pdf/ljActs/(57) The Ambernath Interim Municipality Validation Act, 1965) (2012) (H 4180).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Ambernath
                                Interim Municipality (Constitution and Actions) Validation Act, 1965.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            1909
                        </td>
                        <td>
                            <a href="pdf/ljActs/26-The Chhatrapati Shivaji Mar.Vastu Sang.Act-1909.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Chhatrapati Shivaji
                                Maharaj Vastu Sangrahalaya Act, 1909.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            12
                        </td>
                        <td>
                            1888
                        </td>
                        <td>
                            <a href="pdf/ljActs/18-The City of Bombay Municipal Suppi. Act-1888.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The City Of Bombay Municipal
                                (Supplementary) Act, 1888. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            1
                        </td>
                        <td>
                            1898
                        </td>
                        <td>
                            <a href="pdf/ljActs/17-The City of Bombay Municipal Investments Act-1888.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The City Of Bombay Municipal
                                Investments Act, 1898.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            29
                        </td>
                        <td>
                            1827
                        </td>
                        <td>
                            <a href="pdf/ljActs/21-Bombay Regulation xxix of 1827 The Dekkhan &amp; Khan..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Dekkhan
                                and Khandesh (Puna, Ahmednagar and Khandesh Districts).</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            54
                        </td>
                        <td>
                            1947
                        </td>
                        <td>
                            <a href="pdf/ljActs/(33) Dispositions of Property Validation Act (E) (H 797).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Dispositions
                                Of Property (Bombay) Validation Act, 1947.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            17
                        </td>
                        <td>
                            1953
                        </td>
                        <td>
                            <a href="pdf/ljActs/24-The Gandhi National Memorial Fund Act-1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Gandhi National Memorial
                                Fund (Local Authorities Donations) Act, 1953.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            5
                        </td>
                        <td>
                            1863
                        </td>
                        <td>
                            <a href="pdf/ljActs/15-The Gas Companies Act-1863.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Gas Companies Act, 1863.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            17
                        </td>
                        <td>
                            1945
                        </td>
                        <td>
                            <a href="pdf/ljActs/14-The Gr.Bom. Laws &amp; The Bombay H.C.Dec.L.Act-1945.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Greater
                                Bombay Laws and the Bombay High Court (Declaration of Limits) Act, 1945.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            11
                        </td>
                        <td>
                            1926
                        </td>
                        <td>
                            <a href="pdf/ljActs/(63) The Invalidation of Hindu Ceremonial Emoluments Act, 1926 (H 4179).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Invalidation
                                of Hindu Ceremonial Emoluments Act, 1926.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            8
                        </td>
                        <td>
                            1978
                        </td>
                        <td>
                            <a href="pdf/ljActs/(52) Leader of oposition Legislative Salaries Act (E) 1978 (H 1046).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Leaders
                                of Opposition in Maharashtra Legislature Salaries and Allowances Act, 1978.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            1888
                        </td>
                        <td>
                            <a href="pdf/ljActs/(72) The Mumbai Municipal Corporation Act Bombay Act No. III of 1888 (H 4169)..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Mumbai
                                Municipal Corporation Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            34
                        </td>
                        <td>
                            1982
                        </td>
                        <td>
                            <a href="pdf/ljActs/(31) The Pulgaon Cotton Mills Act (E) (H 795).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Pulgaon Cotton Mills
                                Limited (Acquisition Of Shares) Act, 1982.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            36
                        </td>
                        <td>
                            1984
                        </td>
                        <td>
                            <a href="pdf/ljActs/(27) Shivraj Fine Art Litho Works Act (E) (H 791).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Shivraj Fine Art Litho
                                Works (Acquisition And Transfer Of Undertaking) Act, 1984.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            11
                        </td>
                        <td>
                            1853
                        </td>
                        <td>
                            <a href="pdf/ljActs/(62) The Shore Nuisances (Bombay and Kolaba) Act (H 4178).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Shore
                                Nuisances (Bombay And Kolaba) Act, 1853.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            1875
                        </td>
                        <td>
                            <a href="pdf/ljActs/(30) The Toll on Roads and Bridges Act (E) (H 794).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Tolls On Roads And
                                Bridges Act, 1875.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            20
                        </td>
                        <td>
                            1989
                        </td>
                        <td>
                            <a href="pdf/ljActs/The Yashwantrao Chavan Maharashtra Open University Act, 1989..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Yashwantrao
                                Chavan Maharashtra Open University Act, 1989.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            39
                        </td>
                        <td>
                            1957
                        </td>
                        <td>
                            <a href="pdf/ljActs/BOM. XXXIX OF 1957.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">
                                Bom. Abolition of Whipping Act, 1957 </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            40
                        </td>
                        <td>
                            1963
                        </td>
                        <td>
                            <a href="pdf/ljActs/Maharashtra Act No. XL of 1963.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Deletion of the Term "Famine" (From Laws
                                Applicable to the State) Act, 1969 </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            25
                        </td>
                        <td>
                            1960
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. XXV OF 1960.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Evacuee Interest (Separation) Supplementary
                                Act, 1960 </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            23
                        </td>
                        <td>
                            1994
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. XXIII OF 1994..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Finance Commission (Miscellaneous Provisions)
                                Act, 1994. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            44
                        </td>
                        <td>
                            1953
                        </td>
                        <td>
                            <a href="pdf/ljActs/BOMBAY ACT No. XLIV OF.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Kauli And Katuban Tenures (Abolition)
                                Act </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            25
                        </td>
                        <td>
                            1996
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. XXV OF 1996..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Restoration of Name "Mumbai" for "Bombay"
                                Act, 1996. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            2
                        </td>
                        <td>
                            1894
                        </td>
                        <td>
                            <a href="pdf/ljActs/BOMBAY ACT No. II OF 1894.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Peint Laws Act, 1894</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            8
                        </td>
                        <td>
                            1827
                        </td>
                        <td>
                            <a href="pdf/ljActs/Bombay Regulation VIII of 1827.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Administration of Estates Regulation</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            Reg. 2
                        </td>
                        <td>
                            1950
                        </td>
                        <td>
                            <a href="pdf/ljActs/THE BOMBAY BUILDINGTHE BOMBAY BUILDING.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Building (Control on Erection) Regulation,
                                1950 </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            28
                        </td>
                        <td>
                            1993
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT NO. XXVIII OF 1993.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Groundwater (Regulation for DrinkingWater
                                Purposes) Act, 1993</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            46
                        </td>
                        <td>
                            1971
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. XLVI OF 1971.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Lokayukta and Upa-Lokayuktas Act, 1971</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            31
                        </td>
                        <td>
                            1982
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. XXXI OF 1982..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Prevention of Malpractices at University,
                                Board and other Specified Examinations act, 1982. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            Reg. 1
                        </td>
                        <td>
                            1952
                        </td>
                        <td>
                            <a href="pdf/ljActs/THE AKRANI MAHAL.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">
                                The Akrani Mahal (Application of Laws) Regulation, 1952 </a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            44
                        </td>
                        <td>
                            1949
                        </td>
                        <td>
                            <a href="pdf/ljActs/BOMBAY ACT No. XLIV OF 1949.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The City of Bombay (Building Works Restriction)
                                Act, 1949</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            11
                        </td>
                        <td>
                            1979
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. XI OF 1979.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Mah. Khar Lands Development Act, 1979</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            46
                        </td>
                        <td>
                            1975
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. LXVI OF 1975..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Mah. Vacant Lands (Prohibition Of Unauthorised
                                Occupation and Summary Eviction) Act, 1975. </a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            1
                        </td>
                        <td>
                            1961
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. I OF 1961..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Mah.Fisheries Act, 1960</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            4
                        </td>
                        <td>
                            1862
                        </td>
                        <td>
                            <a href="pdf/ljActs/Bombay Act No. IV of 1862.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Markets and Fairs Act, 1862</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            4
                        </td>
                        <td>
                            1936
                        </td>
                        <td>
                            <a href="pdf/ljActs/Act No. IV of 1936..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">
                                The Payment of Wages Act</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            3
                        </td>
                        <td>
                            1973
                        </td>
                        <td>
                            <a href="pdf/ljActs/MAHARASHTRA ACT No. III OF 1973.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Surgeon General with Government, etc (Change
                                in Designation Act), 1972</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            1
                        </td>
                        <td>
                            1889
                        </td>
                        <td>
                            <a href="pdf/ljActs/VILLAGE SANITATION ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">01 1889 Mah. Village Sanitation Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            26
                        </td>
                        <td>
                            1946
                        </td>
                        <td>
                            <a href="pdf/ljActs/COTTON (STATISTICS) ACT, 1946.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bom. Cotton (Statistics) Act, 1946</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            20
                        </td>
                        <td>
                            1978
                        </td>
                        <td>
                            <a href="pdf/ljActs/EMPLOYMENT GUARANTEE ACT, 1977..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Employment Guarantee Act, 1977.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            34
                        </td>
                        <td>
                            1964
                        </td>
                        <td>
                            <a href="pdf/ljActs/FELLING OF TREES ACT, 1964..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Felling of Trees (Regulation) Act, 1964.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            48
                        </td>
                        <td>
                            1976
                        </td>
                        <td>
                            <a href="pdf/ljActs/JEEVAN AUTHORITY ACT, 1976..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Jeevan Authority Act, 1976.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            19
                        </td>
                        <td>
                            1960
                        </td>
                        <td>
                            <a href="pdf/ljActs/KHADI AND VILLAGE INDUSTRIES ACT.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Khadi and Village Industries Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            28
                        </td>
                        <td>
                            1961
                        </td>
                        <td>
                            <a href="pdf/ljActs/MEDICAL PRACTITIONERS ACT, 1961..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Medical Practitioners Act, 1961.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            4
                        </td>
                        <td>
                            1950
                        </td>
                        <td>
                            <a href="pdf/ljActs/MERGED STATES (LAWS) ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Merged States (Laws) Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            25
                        </td>
                        <td>
                            1949
                        </td>
                        <td>
                            <a href="pdf/ljActs/PROHIBITION ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">
                                Mah. Prohibition Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            2
                        </td>
                        <td>
                            1966
                        </td>
                        <td>
                            <a href="pdf/ljActs/REQUISITIONING OF MOTOR VEHICLES ACT, 1965..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Requisitioning (and
                                Control) of Motor Vehicles Act, 1965.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            41
                        </td>
                        <td>
                            1965
                        </td>
                        <td>
                            <a href="pdf/ljActs/SECONDARY AND HIGHER SECONDARY EDUCATION BOARDS ACT, 1965..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Secondary
                                and Higher Secondary Education Boards Act, 1965.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            2
                        </td>
                        <td>
                            1957
                        </td>
                        <td>
                            <a href="pdf/ljActs/SHETGI WATAN RIGHTS ABOLITION ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Shetgi Watan Rights (Ratnagiri) Abolition
                                Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            28
                        </td>
                        <td>
                            1971
                        </td>
                        <td>
                            <a href="pdf/ljActs/SLUM AREAS ACT, 1971..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Slum Areas (Improvement, Clearance and
                                Redevelopment) Act, 1971.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            56
                        </td>
                        <td>
                            1959
                        </td>
                        <td>
                            <a href="pdf/ljActs/COMMISSIONERS OF POLICE ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. State Commissioners of Police Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            32
                        </td>
                        <td>
                            1969
                        </td>
                        <td>
                            <a href="pdf/ljActs/LEGISLATURE PROCEEDINGS ACT, 1969..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. State Legislature Proceedings (Protection
                                of Publication) Act, 1969.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            71
                        </td>
                        <td>
                            1959
                        </td>
                        <td>
                            <a href="pdf/ljActs/STATUTORY FUNDS ACT.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">
                                Mah. Statutory Funds Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            5
                        </td>
                        <td>
                            1977
                        </td>
                        <td>
                            <a href="pdf/ljActs/TRIBALS ECONOMIC CONDITION (IMPROVEMENT) ACT, 1976..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah. Tribals Economic Condition
                                (Improvement) Act, 1976.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            22
                        </td>
                        <td>
                            1969
                        </td>
                        <td>
                            <a href="pdf/ljActs/AGRICULTURAL DEBTORS RELIEF ACT, 1969.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah.(Vidarbha Region)Agricultural Debtors
                                Relief Act, 1969</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            8
                        </td>
                        <td>
                            1958
                        </td>
                        <td>
                            <a href="pdf/ljActs/COMMISSIONERS OF DIVISIONS ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mah.Commissioners of Divisions Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            20
                        </td>
                        <td>
                            1936
                        </td>
                        <td>
                            <a href="pdf/ljActs/OPIUM SMOKING ACT.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">
                                Mah.Opium Smoking Act.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            14
                        </td>
                        <td>
                            1866
                        </td>
                        <td>
                            <a href="pdf/ljActs/THE EDULABAD AND WARANGAON PARGANAS LAWS ACT, 1866..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Edulabad and Warangaon
                                Parganas Laws Act, 1866.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even">
                        <td>
                            47
                        </td>
                        <td>
                            1951
                        </td>
                        <td>
                            <a href="pdf/ljActs/THE SALSETTE ESTATES ACT, 1951..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Salsette Estates (Land Revenue Exemption
                                Abolition) Act, 1951.</a>
                        </td>
                    </tr>
                    <tr role="row" class="odd">
                        <td>
                            3
                        </td>
                        <td>
                            1863
                        </td>
                        <td>
                            <a href="pdf/ljActs/THE SATARA, SHOLAPUR AND SOUTHERN MARATHA COUNTRY LAWS ACT, .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Satara,
                                Sholapur and Southern Maratha Country Laws Act, 1863.</a>
                        </td>
                    </tr>
                    <tr role="row" class="even"><td>20</td><td>1946</td><td><a href="pdf/29062015/H-1780 Bombay  Act  No.  XX  of  1946..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Electricity (Special Powers) Act, 1946</a></td></tr><tr role="row" class="odd"><td>46</td><td>1971</td><td><a href="pdf/29062015/H-436 Maha. Lokaukta &amp;Up lokaukat.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Lokayukta and Upa-Lokayuktas Act, 1971</a></td></tr><tr role="row" class="even"><td>09</td><td>1974</td><td><a href="pdf/29062015/PANDHARPUR TEMPLES ACT1973.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Pandharpur Temples Act, 1973</a></td></tr><tr role="row" class="odd"><td>44</td><td>1975</td><td><a href="pdf/29062015/The Maharashtra (Urban Areas) Protection and Preservation of Trees Act, 1975..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">(Urban Areas) Protection and Preservation of Trees Act, 1975 </a></td></tr><tr role="row" class="even"><td>16</td><td>1985</td><td><a href="pdf/29062015/The maharashtra abolition of subsisting proprietary rights to mines and minerals in certain lands.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Abolition of Subsisting Proprietary Rights to Mines and Minerals in Certain Lands Act, 1985</a></td></tr><tr role="row" class="odd"><td>29</td><td>1957</td><td><a href="pdf/29062015/H-1784 BOM. XXXIX OF 1957.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Abolition of Whiping Act, 1957</a></td></tr><tr role="row" class="even"><td></td><td>1960</td><td><a href="pdf/29062015/Act-(J) 38 1.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Adaptation of Laws (state and concurrent subjects) order 1960</a></td></tr><tr role="row" class="odd"><td>18</td><td>1967</td><td><a href="pdf/29062015/The Maharashtra Advertisements Tax Act, 1967.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Advertisement Tax Act, 1967</a></td></tr><tr role="row" class="even"><td>27</td><td>1961</td><td><a href="pdf/29062015/The Maharashtra Agricultural Lands (Ceiling on Holdings) Act, 1961..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Lands (Ceilling and Holdings) Act, 1961</a></td></tr><tr role="row" class="odd"><td>43</td><td>1947</td><td><a href="pdf/29062015/THE MAHARASHTRA AGRICULTURAL PESTS AND DISEASES ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Pests and Deseases Act, 1947</a></td></tr><tr role="row" class="even"><td>3</td><td>2015</td><td><a href="pdf/29062015/Mah. Act 3 of 2015 Ajeenkya DY Patil University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Ajeenkya DY Patil University Act, 2014</a></td></tr><tr role="row" class="odd"><td>13</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 13 of 2014 Amity University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Amity University Act, 2014</a></td></tr><tr role="row" class="even"><td></td><td>1949</td><td><a href="pdf/29062015/S (J) 226 -- The Maharashtra Anotomy Act 17-4-2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Anatomy Act, 1949 </a></td></tr><tr role="row" class="odd"><td>15</td><td>1971</td><td><a href="pdf/29062015/The Maharashtra Apartment Ownership Act, 1970..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Apartment Ownership Act, 1970</a></td></tr><tr role="row" class="even"><td>32</td><td>1949</td><td><a href="pdf/29062015/The maharashtra bhagdari and narwadari tenures abolition Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bhagdari and Narwadari Tenures Abolition Act, 1949</a></td></tr><tr role="row" class="odd"><td>21</td><td>1955</td><td><a href="pdf/29062015/The MAHARASHTRA Bhil naik inams abolition Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bhil Naik Inams Abolition Act, 1955</a></td></tr><tr role="row" class="even"><td>31</td><td>1976</td><td><a href="pdf/29062015/THE MAHARASHTRA CASINOS (CONTROL AND TAX) ACT, 1976..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Casinos (Control and Tax) Act, 1976</a></td></tr><tr role="row" class="odd"><td>67</td><td>1959</td><td><a href="pdf/29062015/The Central Provinces and BerAr State Aid to Industries and The Hyderabad State Aid to (Small-Sca.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Central Provinces and Berar State Aid Industries and Hyderabad State Aid to (Small-Scale and Cottage) Industries (Partial Repeal) Act, 1959 </a></td></tr><tr role="row" class="even"><td>24</td><td>2012</td><td><a href="pdf/29062015/The MAHARASHTRA (CHANGE OF SHORT TITLES OF CERTAIN BOMBAY ACTS) Act, 2011..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Change of Short Titles of Certain Bombay Acts</a></td></tr><tr role="row" class="odd"><td>06</td><td>1890</td><td><a href="pdf/29062015/THE CHARITABLE ENDOWMENTS ACT 1890.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Charitable Endowment Act, 1890</a></td></tr><tr role="row" class="even"><td>11</td><td>1953</td><td><a href="pdf/29062015/The maharashtra Cinemas (Regulation) Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Cinemas (Regulation) Act, 1953</a></td></tr><tr role="row" class="odd"><td>02</td><td>1874</td><td><a href="pdf/29062015/The Civil Jails Act, 1874..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Civil Jails Act</a></td></tr><tr role="row" class="even"><td></td><td>1984</td><td><a href="pdf/29062015/H-1753 Maharashtra civil services ruls 1984.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Civil Services Rules, 1984</a></td></tr><tr role="row" class="odd"><td>30</td><td>1942</td><td><a href="pdf/29062015/The Bombay Cotton Control Act, 1942..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Cotton Control Act, 1942</a></td></tr><tr role="row" class="even"><td>01</td><td>1905</td><td><a href="pdf/29062015/The Bombay Court of Wards Act, 1905..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Courts of Wards Act, 1905</a></td></tr><tr role="row" class="odd"><td>40</td><td>1963</td><td><a href="pdf/29062015/H-1793 Maharashtra Act No. XL of 1963.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Delation of the Term "Famine" (From  Laws Applicable to the State) Act, 1969</a></td></tr><tr role="row" class="even"><td>46</td><td>1958</td><td><a href="pdf/29062015/BOMBAY DISQUALIFICATION OF MUNICIPAL COUNCILLORS (REMOVAL OF DOUBTS) ACT, 1958..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Disqualifications of Municipal Councillors (Removal of Doubts) Act, 1958</a></td></tr><tr role="row" class="odd"><td>24</td><td>1998</td><td><a href="pdf/29062015/The Maharashtra district planning committees (constitution and functions) Act, 1998..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">District Planning Committees (Constitution and Functions) Act, 1998</a></td></tr><tr role="row" class="even"><td>33</td><td>1976</td><td><a href="pdf/29062015/The Maharashtra Dog Race-Courses Licensing Act, 1976..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Dog Race-Courses Licencing Act, 1976</a></td></tr><tr role="row" class="odd"><td>29</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 29 of 2014 Dr. Babasaheb Ambedkar Technological University Act, 2014..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Dr. Babasaheb Amedkar Technological University Act, 2014</a></td></tr><tr role="row" class="even"><td>6</td><td>1988</td><td><a href="pdf/29062015/The Maharashtra Educational Institutions (Prohibition of Capitation Fee) Act, 1987..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Educational Institutions (Prohibition of Capitation Fee) Act, 1987</a></td></tr><tr role="row" class="odd"><td>07</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 7 of 2014 Maharashtra Educational institutions (Regulation of Fee) Act, 2011..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Educational Institutions (Regulation of Fee) Act, 2014</a></td></tr><tr role="row" class="even"><td>1</td><td>1955</td><td><a href="pdf/29062015/H-1781 Bombay Regulation  No. I  of 1955..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Electricity (Special Powers) Act (Applicatio to Scheduled Areas) Regulation, 1955</a></td></tr><tr role="row" class="odd"><td>3</td><td>1978</td><td><a href="pdf/29062015/S (J) 291 -- The Maharashtra Employees of private Schools (c.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Employees of Private Schools (Conditions of Service) Regulation Act, 1977</a></td></tr><tr role="row" class="even"><td>42</td><td>1958</td><td><a href="pdf/29062015/The Bombay Essential Commodities and Cattle (Control) Act, 1958..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Essential Commodities and Cattle Control Act, 1958</a></td></tr><tr role="row" class="odd"><td>12</td><td>2012</td><td><a href="pdf/29062015/The MAHARASHTRA ESSENTIAL SERVICES MAINTENANCE Act, 2011..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Essential Services Maintenance Act, 2012</a></td></tr><tr role="row" class="even"><td>25</td><td>1960</td><td><a href="pdf/29062015/H-1782 PDF MAHARASHTRA ACT No. XXV OF 1960.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Evacuee Interest (SEPARATION) SUPPLEMENTARY Act, 1960</a></td></tr><tr role="row" class="odd"><td>02</td><td>1863</td><td><a href="pdf/29062015/J-36 Land 0000.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Exemption From Land Revenue (No-1) Act, 1863</a></td></tr><tr role="row" class="even"><td>23</td><td>1994</td><td><a href="pdf/29062015/H-1766 Maharashtra  Act  No. XXIII of 1994..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Finance Commission (Miscllaneous Provisions) Act, 1994</a></td></tr><tr role="row" class="odd"><td>1</td><td>1961</td><td><a href="pdf/29062015/H-1765 The Maharashtra Fisheries  Act, 1960.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Fisheries Act, 1960</a></td></tr><tr role="row" class="even"><td>2</td><td>2015</td><td><a href="pdf/29062015/Mah. Act 2 of 2015 FLAME University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">FLAME University Act, 2014</a></td></tr><tr role="row" class="odd"><td>26</td><td>1939</td><td><a href="pdf/29062015/J-37 Grain 000.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Fodder and Grain Control Act, 1939</a></td></tr><tr role="row" class="even"><td>57</td><td>1969</td><td><a href="pdf/29062015/S (J) 224 -- The  Maharashtra Forest Produce (Regulation of .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Forest Produce (Regulation of Trade) Act, 1969</a></td></tr><tr role="row" class="odd"><td>1</td><td>1904</td><td><a href="pdf/29062015/The maharashtra General Clauses Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">General Clauses Act, 1904</a></td></tr><tr role="row" class="even"><td>23</td><td>1998</td><td><a href="pdf/29062015/THE  MAHARASHTRA  GODAVARI  MARATHWADA IRRIGATION  DEVELOPMENT  CORPORATION  ACT,  1998..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Godavari Marathwada Irrigation Development Corporation Act, 1998</a></td></tr><tr role="row" class="odd"><td>44</td><td>1965</td><td><a href="pdf/29062015/THE MAHARASHTRA GOVERNMENT SERVANTS INQUIRIES (EVIDENCE OF CORRUPTION) ACT, 1965..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Government Servants Inquiries (Evidence of Corruption) Act, 1965</a></td></tr><tr role="row" class="even"><td>23</td><td>1965</td><td><a href="pdf/29062015/The Maharashtra Gramdan Act, 1964..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Gramdan Act, 1964</a></td></tr><tr role="row" class="odd"><td>26</td><td>2013</td><td><a href="pdf/29062015/Mah. Act No. 26 of 2013 Maharashtra Groundwater (Development and Management) Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Groundwater (Development and Management) Act, 2009</a></td></tr><tr role="row" class="even"><td>28</td><td>1993</td><td><a href="pdf/29062015/H-1757 Maharashtra  Act  No. XXvIII of 1993.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Groundwater (Regulation for Drinking Water Purposes) Act, 1993</a></td></tr><tr role="row" class="odd"><td>55</td><td>1955</td><td><a href="pdf/29062015/THE MAHARASHTRA HIGHWAYS ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Highways Act, 1955</a></td></tr><tr role="row" class="even"><td>31</td><td>1956</td><td><a href="pdf/29062015/The MAHARASHTRA hindu places of public worship (entry authorization) act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Hindu Places of Public Workship (Entry Authorization) Act, 1956</a></td></tr><tr role="row" class="odd"><td>19</td><td>1947</td><td><a href="pdf/29062015/The BOMBAY HINDU women's rights to property (extension to agricultural land) Act, 1947..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Hindu Women's Rights to Property (Extention to Agricultureal Land)</a></td></tr><tr role="row" class="even"><td>12</td><td>1960</td><td><a href="pdf/29062015/H-1812 bombay Act No. XII of 1960.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Homoeopathic Practitioners Act</a></td></tr><tr role="row" class="odd"><td>25</td><td>1988</td><td><a href="pdf/29062015/S (J) 228 -- The Maharashtra Horticulture Development Corpor.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Horiculture Development Corporation Act, 1984</a></td></tr><tr role="row" class="even"><td>02</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 2 of 2014 Maharashtra Housing (Regulation and Development) Act, 2012.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Housing (Regulation and Development) Act, 2012</a></td></tr><tr role="row" class="odd"><td>3</td><td>1962</td><td><a href="pdf/29062015/S (J) 220 -- The Maharashtra Industrial Development Act, 196.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Industrial Development Act, 1961</a></td></tr><tr role="row" class="even"><td>10</td><td>1973</td><td><a href="pdf/29062015/S (J) 227 -- The Maharashtra Indutrial Relations (Validation.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Industrial Relation (Validation of Certain Proceedings) Act, 1972</a></td></tr><tr role="row" class="odd"><td>11</td><td>1947</td><td><a href="pdf/29062015/H-438 Bombay Act No. XI of 1947.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Industrial Relation Act, 1946</a></td></tr><tr role="row" class="even"><td>1</td><td>1959</td><td><a href="pdf/29062015/The maharashtra Inferior Village Watans Abolition Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Inferior Village Watans Abolition Act, 1958</a></td></tr><tr role="row" class="odd"><td>38</td><td>1976</td><td><a href="pdf/29062015/H-1813 The  Maharashtra  Irrigation  Act,  1976..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Irregation Act, 1976</a></td></tr><tr role="row" class="even"><td>33</td><td>1997</td><td><a href="pdf/29062015/The KAVI KULAGURU KALIDAS SANSKRIT VISHVAVIDYALAYA (UNIVERSITY) Act, 1997..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Kavi Kulguru Kalidas Sanskrit Vishvavidyalaya (University) Act, 1997</a></td></tr><tr role="row" class="odd"><td>11</td><td>1979</td><td><a href="pdf/29062015/H-1767 Maharashtra Act No. XI of 1979.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Kharlands Development Act, 1979</a></td></tr><tr role="row" class="even"><td>12</td><td>1983</td><td><a href="pdf/29062015/S (J) 218 -- The Maharashtra Kidney Transplantation Act, 198.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Kidney Transplatation Act, 1982</a></td></tr><tr role="row" class="odd"><td>15</td><td>1996</td><td><a href="pdf/29062015/The Krishna Valley Development Corporation Act, 1996.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Krishna Valley Development Corporation Act, 1996</a></td></tr><tr role="row" class="even"><td>23</td><td>1948</td><td><a href="pdf/29062015/S (J) 223 -- The Maharashtra Land Requisition Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Requisition Act, 1948</a></td></tr><tr role="row" class="odd"><td>25</td><td>1972</td><td><a href="pdf/29062015/S (J) 235 -- The Maharashtra Land Revenue (Revival of Certai.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Revenue (Revivial of certain Rules Relating 1 to Non-Agricultural Assesment) Act, 1972</a></td></tr><tr role="row" class="even"><td>41</td><td>1966</td><td><a href="pdf/29062015/H-634 The  Maharashtra  Land  Revenue  Code, 1966..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Revenue Code, 1966</a></td></tr><tr role="row" class="odd"><td>52</td><td>1956</td><td><a href="pdf/29062015/H-1762 Bombay act No. LII of 1956..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Legislature Members (Removal of Disqualifications) Act, 1956</a></td></tr><tr role="row" class="even"><td>10</td><td>1939</td><td><a href="pdf/29062015/S (J) 221 -- The Maharashtra Lift Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Lift Act, 1939</a></td></tr><tr role="row" class="odd"><td>22</td><td>1933</td><td><a href="pdf/29062015/The Maharashtra Live-stock Improvement ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Live-Stock Improvement Act,</a></td></tr><tr role="row" class="even"><td>20</td><td>1987</td><td><a href="pdf/29062015/S (J) 222 -- The Maharashtra Local Authority Members" disqua.pdf'="" target="_blank" alt="Download PDF" title="Click here to open in new tab">Local Authority Members Disqualification Act, 1986</a></td></tr><tr role="row" class="odd"><td>25</td><td>1930</td><td><a href="pdf/29062015/The maharashtra Local fund Audit Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Local Fund Audit Act, 1930</a></td></tr><tr role="row" class="even"><td>82</td><td>1958</td><td><a href="pdf/29062015/H-1760 BOMBAY  Act  No.  LXXXII of 1958..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Lotteries (Control and Tax) and Prize Competetion (Tax) Act</a></td></tr><tr role="row" class="odd"><td>5</td><td>1985</td><td><a href="pdf/29062015/The Maharashtra Luxury-cum-Entertainment and Amusement Tax on Holders of Television Sets (Repeal).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Luxury-cum-Entertainment and Amusement Tax on Holders of Television Sets (Repeal) Act, 1985</a></td></tr><tr role="row" class="even"><td>1</td><td>1951</td><td><a href="pdf/29062015/S (J) 234 -- Madhya Pradesh Abolition of Proprietary Rights .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Madya Pradesh Abolition of Proprietary Rights (Estates, Mahals, Alienated Lands) Act, 1950</a></td></tr><tr role="row" class="odd"><td>18</td><td>1968</td><td><a href="pdf/29062015/H-1759 Maharashtra  Act  No.  XVIII  of 1968.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mahatma Phule Vastusangrahalaya, Poona, Act, 1968</a></td></tr><tr role="row" class="even"><td>4</td><td>1922</td><td><a href="pdf/29062015/H-1778 bombay Act No. IV of 1922.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mahul Creek (Extinguishment of Right) Act, 1922</a></td></tr><tr role="row" class="odd"><td>2</td><td>1906</td><td><a href="pdf/29062015/The Mamlatdar's Courts Act, 1906..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mamlatdar's Courts Act, 1906</a></td></tr><tr role="row" class="even"><td>54</td><td>1981</td><td><a href="pdf/29062015/Maharashtra Marine Fishing Regulation Act, 1981.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Marine Fishing Regulation Act, 1981</a></td></tr><tr role="row" class="odd"><td>4</td><td>1862</td><td><a href="pdf/29062015/H-1775 The Markets and Fairs Act, 1862.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Markets and Fairs Act</a></td></tr><tr role="row" class="even"><td>30</td><td>1969</td><td><a href="pdf/29062015/H-1755 Maharashtra  Act No. XXX of 1969.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mathadi, Hamal and othe Manual Workers (Regulation of Employment and Welfare) Act, 1969</a></td></tr><tr role="row" class="odd"><td>46</td><td>1965</td><td><a href="pdf/29062015/S (J) 217 -- The Maharashtra Medical Council Act, 1965  .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Medical Council Act, 1965</a></td></tr><tr role="row" class="even"><td>28</td><td>1961</td><td><a href="pdf/29062015/MEDICAL PRACTITIONERS ACT, 1961..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Medical Practioners Act, 1961</a></td></tr><tr role="row" class="odd"><td>89</td><td>1954</td><td><a href="pdf/29062015/THE BOMBAY MERGED TERRITORIES AND AREAS (JAGIRS ABOLITION) ACT, 1953..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Merged Territories and Areas (Jagirs Abolitions) Act, 1954</a></td></tr><tr role="row" class="even"><td>4</td><td>1975</td><td><a href="pdf/29062015/S (J) 290 -- The Mumbai Metropolition Region Development Aut.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Metropolitan Region Development Authority Act, 1974</a></td></tr><tr role="row" class="odd"><td>42</td><td>1983</td><td><a href="pdf/29062015/The Mumbai Metropolitan Region Specified Commodities Markets (Regulation of Location) Act, 1983..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Metropolitan Region Specified Commodities Markets (Regulation of Location) Act,1983</a></td></tr><tr role="row" class="even"><td>8</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 8 of 2014 Maharashtra Money-Lending (Regulation) Act, 2014..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Money-Lending (Regulation) Act, 2014</a></td></tr><tr role="row" class="odd"><td>67</td><td>1958</td><td><a href="pdf/29062015/The maharashtra MOTOR VEHICLES ( TAXATION OF PASSENGERS ) Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Motor Vehicles (Taxation of Passengers)  Act, 1958</a></td></tr><tr role="row" class="even"><td>65</td><td>1958</td><td><a href="pdf/29062015/The Maharashtra Motor Vehicles Tax Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Motor Vehicles Tax Act, 1958</a></td></tr><tr role="row" class="odd"><td>7</td><td>1950</td><td><a href="pdf/29062015/S (J) 239 -- The Bombay Municipal (Extension of Limits) Act,.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal (Extention of Limits) Act, 1950</a></td></tr><tr role="row" class="even"><td>5</td><td>1890</td><td><a href="pdf/29062015/BOMBAY MUNICIPAL SERVANTS ACT, 1890..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Servants Act, 1890</a></td></tr><tr role="row" class="odd"><td>36</td><td>1936</td><td><a href="pdf/29062015/H-1809 The Nagpur Improvement Trust Act, 1936.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Nagpur Improvement Trust Act, 1936</a></td></tr><tr role="row" class="even"><td>23</td><td>1971</td><td><a href="pdf/29062015/H-1758 MAHARASHTRA  Act  No.  XXIII  of 1971.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">National and State Parks Act, 1970</a></td></tr><tr role="row" class="odd"><td>6</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 6 of 2014 Maharashtra National Law University Act, 2014..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">National Law University Act, 2014</a></td></tr><tr role="row" class="even"><td>26</td><td>1959</td><td><a href="pdf/29062015/The MAHARASHTRA Non-Trading Corporations Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Non-Trading Corporations Act, 1959</a></td></tr><tr role="row" class="odd"><td>40</td><td>1966</td><td><a href="pdf/29062015/The Maharashtra Nurses Act, 1966..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Nurses Act, 1965</a></td></tr><tr role="row" class="even"><td>60</td><td>1950</td><td><a href="pdf/29062015/The MAHARASHTRA Pargana and Kulkarni Watans (Abolition) Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Pargana and Kulkarni Watans (Abolition) Act, 1950</a></td></tr><tr role="row" class="odd"><td>4</td><td>1936</td><td><a href="pdf/29062015/H-1815 Act  No.  IV  of 1936..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Payment of Wages Act, 1936</a></td></tr><tr role="row" class="even"><td>42</td><td>1953</td><td><a href="pdf/29062015/BOMBAY ACT No. XLII OF 1953 THE MAHARASHTRA PERSONAL INAMS ABOLITION ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Personal   Inams Abolition Act, 1953</a></td></tr><tr role="row" class="odd"><td>22</td><td>1951</td><td><a href="pdf/29062015/H-1808 Bombay Act No. XXII oF 1951..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Police Act, 1951</a></td></tr><tr role="row" class="even"><td>31</td><td>1982</td><td><a href="pdf/29062015/H-1761 Maharashtra Act No. XXXI of 1982..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of  Malpractices at University, Board and other Specified Examinations Act, 1982.</a></td></tr><tr role="row" class="odd"><td>10</td><td>1960</td><td><a href="pdf/29062015/The Maharashtra Prevention of Begging Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Begging Act, 1959</a></td></tr><tr role="row" class="even"><td>55</td><td>1981</td><td><a href="pdf/29062015/The Maharashtra Prevention of Dangerous Activities of Slumlords, Bootleggers, Drug-offenders, Dan.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Dangerous Activities of Slumlords, Bootleggers, Drug Offenders, Dangerous Persons and Video Pirates Act, 1981</a></td></tr><tr role="row" class="odd"><td>42</td><td>1947</td><td><a href="pdf/29062015/The Maharashtra Prevention of Fragmentation and Consolidation of Holdings Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Fragmentation and Consolidation of Holdings Act, 1947 </a></td></tr><tr role="row" class="even"><td>4</td><td>1887</td><td><a href="pdf/29062015/The Maharashtra Prevention of Gambling Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Gambling Act, 1887</a></td></tr><tr role="row" class="odd"><td>29</td><td>1975</td><td><a href="pdf/29062015/The Maharashtra Private Forests (Acquisition) Act, 1975..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Private Forest (Acquisition) Act, 1975</a></td></tr><tr role="row" class="even"><td>12</td><td>1957</td><td><a href="pdf/29062015/THE BOMBAY PROHIBITION OF SIMULTANEOUS MEMBERSHIP ACT, 1957..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prohibition of Simultaneous Membership Act, 1957</a></td></tr><tr role="row" class="odd"><td>11</td><td>2001</td><td><a href="pdf/29062015/The Maharashtra Project Affected Persons Rehabilitation Act, 1999..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Project Affected Persons Rehabilitation Act, 1999</a></td></tr><tr role="row" class="even"><td>5</td><td>1963</td><td><a href="pdf/29062015/The maharashtra provisional collection of taxes act, 1962..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Provincial Collection of Taxes Act, 1962</a></td></tr><tr role="row" class="odd"><td>16</td><td>1955</td><td><a href="pdf/29062015/THE PROVINCIAL SMALL CAUSE COURTS (SUITS VALIDATION) Act, 1955.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Provincial Small Cause Courts (Suits Validation) Act, 1955</a></td></tr><tr role="row" class="even"><td>7</td><td>1920</td><td><a href="pdf/29062015/THE  MAHARASHTRA PUBLIC CONVEYANCES ACT.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Public Conveyance Act, 1920</a></td></tr><tr role="row" class="odd"><td>34</td><td>1967</td><td><a href="pdf/29062015/H-1768 The Maharashtra Public Libraries Act, 1967..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Public Libraries Act, 1967</a></td></tr><tr role="row" class="even"><td>9</td><td>1962</td><td><a href="pdf/29062015/H-1810 Maharashtra Act No. iX of 1962.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Purchase Tax on Sugarcane Act, 1962</a></td></tr><tr role="row" class="odd"><td>58</td><td>1947</td><td><a href="pdf/29062015/The bombay rationing (preparatory and continuance) measures act, 1947..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Rationing (Preparatory and Continuance) Measures Act, 1947</a></td></tr><tr role="row" class="even"><td>15</td><td>1988</td><td><a href="pdf/29062015/H-1432 Maharashtra Act No. XV of 1988.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Regulation of use of Pre-natal Diagnostic Techniques Act, 1988</a></td></tr><tr role="row" class="odd"><td>96</td><td>1958</td><td><a href="pdf/29062015/The MAHARASHTRA RelieF Undertakings (Special Provisions) Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Relief Undertakings (Special Provisions) Act, 1958</a></td></tr><tr role="row" class="even"><td>14</td><td>1975</td><td><a href="pdf/29062015/The Maharashtra Restoration of Lands to Scheduled Tribes Act, 1974..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Restoration of Lands to Scheduled Tribes Act, 1974</a></td></tr><tr role="row" class="odd"><td>25</td><td>1996</td><td><a href="pdf/29062015/H-1771 maharashtra  Act  No. xxv of 1996..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Restoration of name "Mumbai" for "Bombay" Act, 1996.</a></td></tr><tr role="row" class="even"><td>35</td><td>1962</td><td><a href="pdf/29062015/The Maharashtra Revenue Patels (Abolition of Office) Act, 1962..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Revenue Patels (Abolition of Office) Act, 1962</a></td></tr><tr role="row" class="odd"><td>23</td><td>1969</td><td><a href="pdf/29062015/The Maharashtra Sale of Trees by Occupants belonging to Scheduled Tribes (Regulation) Act, 1969.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Sale of Trees by Occupants Belonging to Scheduled Tribes (Regulation) Act, 1969</a></td></tr><tr role="row" class="even"><td>1</td><td>2013</td><td><a href="pdf/29062015/Mah. Act  01 of 2013 Maharashtra Self Financed Schools (Establishment &amp; Regulation) Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Self-financed Schools (Establishment &amp; Regulation) Act, 2012</a></td></tr><tr role="row" class="odd"><td>47</td><td>1955</td><td><a href="pdf/29062015/H-1431 THE BOMBAY SHILOTRI RIGHTS.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Shilotri Rights (Kolaba) Abolition Act,1955</a></td></tr><tr role="row" class="even"><td>6</td><td>1981</td><td><a href="pdf/29062015/H-1811 Maharashtra act No. VI of 1981..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Shree Sidhivinayak Ganpati Temple Trust (Prabhadevi) Act, 1980</a></td></tr><tr role="row" class="odd"><td>14</td><td>2004</td><td><a href="pdf/29062015/The Shree Sai Baba Sansthan Trust (Shirdi) Act, 2004..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Shri Sai Baba Sansthan Trust (Shirdi) Act, 2004</a></td></tr><tr role="row" class="even"><td>36</td><td>1957</td><td><a href="pdf/29062015/The Sir Sassoon Jacob David Baronetcy (Repealing) Act, 1957..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Sir Sasoon Jacob David Baronaetcy (Repealing) Act, 1957</a></td></tr><tr role="row" class="odd"><td>7</td><td>1912</td><td><a href="pdf/29062015/THE BOMBAY SMOKE-NUISANCES ACT,  1912..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Smoke-Nuisances Act, 1912</a></td></tr><tr role="row" class="even"><td>52</td><td>1974</td><td><a href="pdf/29062015/S (J) 231 -- The Maharashtra Stamp Duty Act, 1974 .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Special Provision for Payment of Stamp Duty Act, 1974</a></td></tr><tr role="row" class="odd"><td>15</td><td>1951</td><td><a href="pdf/29062015/THE BOMBAY SPECIAL SUITS AND PROCEEDINGS  VALIDATING ACT, 1951..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Special Suits and Proceedings Validating Act, 1951</a></td></tr><tr role="row" class="even"><td>14</td><td>2014</td><td><a href="pdf/29062015/Mah. Act 14 of 2014 Spicer Adventist University Act, 2014..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Spicer Adventist University Act, 2014</a></td></tr><tr role="row" class="odd"><td>17</td><td>1960</td><td><a href="pdf/29062015/The Maharashtra State-Aid to Industries Act, 1960..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Aid to Industries Act, 1960</a></td></tr><tr role="row" class="even"><td>23</td><td>2013</td><td><a href="pdf/29062015/Mah. Act No. 23 of 2013 Maharashtra State Board of Nursing and Paramedical Education Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Board of Nursing and Paramedical Education Act, 2013</a></td></tr><tr role="row" class="odd"><td>44</td><td>1997</td><td><a href="pdf/29062015/The Maharashtra STATE COMMISSION FOR SAFAI KARMACHARIES Act, 1997..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Commission for Safai Karmacharis Act, 1997</a></td></tr><tr role="row" class="even"><td>22</td><td>1994</td><td><a href="pdf/29062015/THE STATE ELECTION COMMISSIONER (QUALIFICATIONS AND APPOINTMENT) ACT, 1994..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Election Commissioner (Qualification &amp; Appointment) Act, 1994</a></td></tr><tr role="row" class="odd"><td>1</td><td>2015</td><td><a href="pdf/29062015/Mah. Act 1 of 2015 Maharashtra State Reservation (ESBC) Act, 2014..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Reservation (of seats for admission in educational institutions in the State and for appointments or posts in the public service under the State) for Educational and Socially Backward Category (ESBC) Act, 2014</a></td></tr><tr role="row" class="even"><td>3</td><td>1987</td><td><a href="pdf/29062015/The Maharashtra Suraksha Dal Act, 1986.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Suraksha Dal Act, 1986</a></td></tr><tr role="row" class="odd"><td>3</td><td>1973</td><td><a href="pdf/29062015/H-1772 MAHARASHTRA ACT No. III OF 1973.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Surgeon General with Government etc. (Change in Designation) Act, 1973</a></td></tr><tr role="row" class="even"><td>4</td><td>1998</td><td><a href="pdf/29062015/THE MAHARASHTRA tapi irrigation development corporation act, 1997..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tapi Irrigation Development Corporation Act, 1997</a></td></tr><tr role="row" class="odd"><td>42</td><td>1987</td><td><a href="pdf/29062015/The Maharashtra Tax on Entry of Motor Vehicles into Local Areas Act, 1987..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on Entry of Motor Vehicles in to Local Areas Act, 1987</a></td></tr><tr role="row" class="even"><td>41</td><td>1987</td><td><a href="pdf/29062015/The Maharashtra Tax on Luxuries Act, 1987.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on Luxuries Act, 1987</a></td></tr><tr role="row" class="odd"><td>21</td><td>1963</td><td><a href="pdf/29062015/The Maharashtra Tax on Sale of Electricity Act, 1963..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on Sale of Electricity Act, 1963</a></td></tr><tr role="row" class="even"><td>44</td><td>1977</td><td><a href="pdf/29062015/H-1774 Maharashtra  Act No. XLIV of 1977..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Taxation of Laws Offences (Extension of Period of Limitation) Act, 1977</a></td></tr><tr role="row" class="odd"><td>46</td><td>1986</td><td><a href="pdf/29062015/H-1785 Maharashtra  Act  No.  XLVI  OF  1986.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">THE CENTRAL INDIA SPINNING, WEAVING AND MANUFACTURING COMPANY LIMITED,THE EMPRESS MILLS, NAGPUR(ACQUISITION AND TRANSFER OF UNDERTAKING) ACT, 1986</a></td></tr><tr role="row" class="even"><td>44</td><td>1949</td><td><a href="pdf/29062015/H-1792 Bombay Act No. XLIV of 1949.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">THE CITY OF BOMBAY (BUILDING WORKS RESTRICTION) ACT, 1949</a></td></tr><tr role="row" class="odd"><td>31</td><td>1997</td><td><a href="pdf/29062015/The Maharashtra truck terminal (regulation of location) Act, 1995..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Truck Terminal (Regulation of Location) Act, 1995</a></td></tr><tr role="row" class="even"><td>20</td><td>2013</td><td><a href="pdf/29062015/Mah. Act  01 of 2013 Maharashtra Self Financed Schools (Establishment &amp; Regulation) Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Unathorized Institutions and Unauthorized Courses of Study in Agricultures, Animal and Fisheri Sciences, Health Sciences, Higher, Technical and Vocational Education (Prohibition) Act, 2013</a></td></tr><tr role="row" class="odd"><td>14</td><td>1976</td><td><a href="pdf/29062015/S (J) 232 -- The Maharashtra Unemployment Allowance payment .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Unemployment Payment to Workmen (for in Factories Temporary Period) Act, 1976</a></td></tr><tr role="row" class="even"><td>35</td><td>1994</td><td><a href="pdf/29062015/Act-(J)-55-I 000.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Universities Act, 1994</a></td></tr><tr role="row" class="odd"><td>66</td><td>1975</td><td><a href="pdf/29062015/H-1770 Maharashtra Act No. LXVI of 1975..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Vacant Lands (Prohibition of Unathorized Occupation Summary  Eviction) Act, 1975</a></td></tr><tr role="row" class="even"><td>37</td><td>1964</td><td><a href="pdf/29062015/H-1434 Maharashtra Act  No.  XXXVII of 1964..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Vaccination Act, 1964</a></td></tr><tr role="row" class="odd"><td>03</td><td>1959</td><td><a href="pdf/29062015/H-1742 THE  MAHARASHTRA  VILLAGE   PANCHAYATS  ACT..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Village Panchayats Act, 1959</a></td></tr><tr role="row" class="even"><td>3</td><td>2001</td><td><a href="pdf/29062015/THE MAHARASHTRA WATER CONSERVATION CORPORATION ACT,  2000..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Water Conservation Corporation Act, 2000</a></td></tr><tr role="row" class="odd"><td>1</td><td>1962</td><td><a href="pdf/29062015/S (J) 233 -- The West Khandeshi Mehwassi Estates (Proprietar.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">West Khandesh Mehwassi Estate (Proprietary Rights Abolition Etc.) Act, 1961</a></td></tr><tr role="row" class="even"><td>20</td><td>1989</td><td><a href="pdf/29062015/The Yashwantrao Chavan Maharashtra Open University Act, 1989..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Yashwantrao Chavan Maharashtra Open University Act, 1989</a></td></tr>
                    <tr role="row" class="odd">
                    <td>20</td>
                    <td>1983</td>
                    <td><a href="pdf/29062015/(2) Mah. Drinking Water Sup. Requisition Act (B) (H 766).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Drinking Water Supply Requisition Act,1983 </a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>18</td>
                    <td>1955</td>
                    <td><a href="pdf/29062015/H-1433 The Bombay Judicial Proceedings  (Regulation of Reports) Act, 1955.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Judicial Proceedings (Regulation of Reports) Act, 1955</a></td>
                    </tr>
                     <tr role="row" class="odd">
                    <td>45</td>
                    <td>1981</td>
                    <td><a href="pdf/29062015/Maharashtra Ownership Flats (Regulation of the Promotion of Construction Sale.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Ownership Flats (Regulation of the Promotion of Construction, Sale, Management and Transfer) Act, 1963</a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>58</td>
                    <td>1963</td>
                    <td><a href="pdf/29062015/Maharashtra Private Security Guards (Regulation of Employment and Welfare) Act, 1981.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Private Security Guards (Regulation of Employment and Welfare) Act, 1981</a></td>
                    </tr>
                    <tr role="row" class="odd">
                    <td>7</td>
                    <td>1981</td>
                    <td><a href="pdf/29062015/The Maharashtra Prevention of Communal, Anti-social and other Dangerous Activities Act, 1980.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Prevention of Communal, Anti-Social and Other Dangerous Activities Act, 1980</a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>30</td>
                    <td>2013</td>
                    <td><a href="pdf/29062015/S (J) 754 -- The Maharashtra Prevention and Eradication of H.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Prevention of Eradication of Human Sacrifice and other Inhuman, Evil and Aghori Practices and Black Magic, 2013</a></td>
                    </tr>
                    <tr role="row" class="odd">
                    <td>30</td>
                    <td>1970</td>
                    <td><a href="pdf/29062015/The Maharashtra Religious Endowments (Reconstruction on Resettlement Sites) Act, 1970.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Religious Endowments (Reconstruction on Resettlement Sites) Act, 1970 </a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>37</td>
                    <td>1966</td>
                    <td><a href="pdf/29062015/Maharashtra Regional and Town Planning Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Regional and Town Planning Act, 1966 </a></td>
                    </tr>
                    <tr role="row" class="odd">
                    <td>33</td>
                    <td>2013</td>
                    <td><a href="pdf/29062015/Mah. Act No. 33 of 2013 Maharashtra Regulation of Sugarcane Price (Supplied to Factories) Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Regulation of Sugarcane Price (Supplied to Factories) Act, 2013</a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>88</td>
                    <td>1958</td>
                    <td><a href="pdf/29062015/The Shore HINDU DIVORCE (DECREES VALIDATION) Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Shore Hindu Divorce (Decrees Validation) Act, 1958</a></td>
                    </tr>
                     <tr role="row" class="odd">
                    <td>33</td>
                    <td>1982</td>
                    <td><a href="pdf/29062015/S (J) 240 -- The Maharashtra Textile Companies (Acquisition .pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Textiles Companies (Acquisition and Transfer of Undertakings) Act, 1982</a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>47</td>
                    <td>1948</td>
                    <td><a href="pdf/29062015/The Mah. Tenency And Agriculture Land  Act (H-4024).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                    Tenancy and Agricultural Lands Act, 1948</a></td>
                    </tr>
                    <tr role="row" class="odd">
                    <td>46</td>
                    <td>1967</td>
                    <td><a href="pdf/29062015/MAHARASHTRA ACT No. XLVIII OF 1971..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                   Vexatious Litigation (Prevention) Act, 1971</a></td>
                    </tr>
                    <tr role="row" class="even">
                    <td>37</td>
                    <td>1956</td>
                    <td><a href="pdf/29062015/The Maharashtra Village Police Act, 1967.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                   Village Police Act, 1967</a></td>
                    </tr>
                     <tr role="row" class="odd">
                    <td>5</td>
                    <td>1962</td>
                    <td><a href="pdf/29062015/Maharashtra Zilla Parishads and Pancyat Samitis Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                   Zilla Parishads and Panchayat Samitis Act, 1961</a></td>
                    </tr>
                      <tr role="row" class="even">
                    <td>60</td>
                    <td>1958</td>
                    <td><a href="pdf/29062015/The Maharashtra Stamp Act..pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> 
                   Stamp Act, 1962</a></td>
                    </tr>

                      <tr role="row" class="odd">
            <td>
                26
            </td>
            <td>
            2014
            </td>
            <td>
            <a href="pdf/29062015/the Maharashtra Employment Guarantee (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Employment Guarantee (Amendment) Act, 2014</a>
            </td>
            </tr>
            <tr role="row" class="even">
            <td>
                16</td>
            <td>2014
            </td>
            <td>
            <a href="pdf/29062015/The Maharashtra Govt. Servants Regulation of Transfers and Prevention of Delay in Discharge of Official Duties (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Government Servants Regulation of Transfers and Prevention of Delay in Discharge of Official Duties (Amendment) Act, 2014</a>
            </td>
            </tr>
            <tr role="row" class="odd">
                <td>
                8</td>
                <td>
                2014
                </td>
                <td>
                <a href="pdf/29062015/The Mah. Money -Lending (Regulation) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Money -Lending (Regulation) Act, 2014</a>
                </td>
            </tr>
              <tr role="row" class="even">
                <td>
                17
                </td>
                <td>
                2014
                </td>
                <td>
                <a href="pdf/29062015/the Maharashtra Agricultural Pests and Diseases (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Pests and Diseases (Amendment) Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                4</td>
              <td>
              2014
              </td>
              <td>
              <a href="pdf/29062015/The Mah. Appropriation (Vote on Account) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Appropriation (Vote on Account) Act, 2014</a>
              </td>
              </tr>
              <tr role="row" class="even">
              <td>
                7</td>
              <td>
              2014
              </td>
              <td>
              <a href="pdf/29062015/The Mah. Educational Instutions (Regulation of Fee) Act, 2011.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Educational Instutions (Regulation of Fee) Act, 2011</a>    
              </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                22</td>
                <td>2014
                </td>
                <td>
                <a href="pdf/29062015/the Maharashtra Entertainments Duty (Amendment and Continuance) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Entertainments Duty (Amendment and Continuance) Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="even">
              <td>
                32</td>
                <td>2014</td>
                <td>
                <a href="pdf/29062015/the Maharashtra Forest Produce (Regulation of Trade) (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Forest Produce (Regulation of Trade) (Amendment) Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                19
              </td>                
             <td>2014</td>
             <td>
             <a href="pdf/29062015/the Maharashtra Homoeopathic Practitioners and the Mah.Medical Council (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Homoeopathic Practitioners' and the Maharashtra Medical Council (Amendment) Act, 2014</a>
             </td>
              </tr> 
              <tr role="row" class="even">
              <td>
                2
              </td>
              <td>
              2014
              </td>
              <td>
              <a href="pdf/29062015/The Mah. Housing (Regulation and Development) Act, 2012.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Housing (Regulation and Development) Act, 2012</a>
              </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                31
              </td>
              <td>
              2014
              </td>
              <td>
              <a href="pdf/29062015/the Maharashtra Land Improvement Schemes (Amendment) Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Improvement Schemes (Amendment) Act, 2013</a>
              </td>
              </tr>
              <tr role="row" class="even">
                <td>
                30</td>
              <td>
              2014
              </td>
              <td><a href="pdf/29062015/the Maharashtra Land Revenue Code (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Revenue Code (Amendment) Act, 2014</a>
              </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                28</td>
                <td>2014</td>
                <td><a href="pdf/29062015/the Maharashtra Medical Practitioners (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Medical Practitioners (Amendment) Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="even">
                <td>
                11</td>
                <td>2014</td>
                <td><a href="pdf/29062015/the Maharashtra Municipal Corporations and Municipal Councils Temporary Postponement of Elections (of the Mayors and Deputy Mayors of Certain ).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Corporations and Municipal Councils Temporary Postponement of Elections (of the Mayors and Deputy Mayors of Certain Municipal Corporations and Presidents of Certain Municipal Council due to ensuing general elections to the State Legislative Asse</a>
                </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                6</td>
                <td>2014</td>
                <td><a href="pdf/29062015/The Mah. National Law University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">National Law University Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="even">
              <td>
                24
              </td>
              <td>2014</td>
              <td><a href="pdf/29062015/the Maharashtra Police (Amendment and Continuance) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Police (Amendment and Continuance) Act, 2014</a>
              </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                15</td>
               <td>2014</td>
               <td><a href="pdf/29062015/The Maharashtra Police (Second Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Police (Second Amendment) Act, 2014</a>
               </td>
              </tr>
              <tr role="row" class="even">
              <td>
                5</td>
              <td>2014</td>
              <td><a href="pdf/29062015/The Mah. Regional and Town Planning (Amendment and Continuance) Act,  2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Regional and Town Planning (Amendment and Continuance) Act,  2014</a>
              </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                9</td>
              <td>2014</td>
              <td><a href="pdf/29062015/The Mah. Slum Areas (Improvement, Clearance and Redevelopment) (Amendment) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Slum Areas (Improvement, Clearance and Redevelopment) (Amendment) Act, 2014</a>
              </td>
              </tr>
              <tr role="row" class="even">
                <td>
                27</td>
                <td>2014</td>
                <td><a href="pdf/29062015/the Maharashtra Tax Laws (Levy, Amendment and Validation) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax Laws (Levy, Amendment and Validation) Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                10</td><td>2014</td><td><a href="pdf/29062015/Tenancy and Agricultural Lands, the Hyderabad Tenancy and Agricultural lands and Bom. Tenancy and Agicultrual Lands (Vidarbha Region) (Amendment) Act, 2011.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tenancy and Agricultural Lands, the Hyderabad Tenancy and Agricultural lands and Bom. Tenancy and Agicultrual Lands (Vidarbha Region) (Amendment) Act, 2011</a>
                </td>
              </tr>
              <tr role="row" class="even">
                <td>
                1</td><td>2014</td><td><a href="pdf/29062015/Tenancy and Agricultural Lands, the Hyderabad Tenancy and Agricultural lands and Bom. Tenancy and Agicultrual Lands (Vidarbha Region) (Amendment) Act, 2012.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tenancy and Agricultural Lands, the Hyderabad Tenancy and Agricultural lands and Bom. Tenancy and Agicultrual Lands (Vidarbha Region) (Amendment) Act, 2012</a>
                </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                13</td><td>2014</td><td><a href="pdf/29062015/The Amity University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Amity University Act, 2014</a></td>
              </tr>
              <tr role="row" class="even">
                <td>
                25</td><td>2014</td><td><a href="pdf/29062015/the City of Mumbai Primary Education Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The City of Mumbai Primary Education, the Maharashtra Primary Education, the Hyderabad Compulsory Primary Education and the Madhya Pradesh Primary Education (Repeal) Act, 2013</a>
                </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                33</td><td>2014</td><td><a href="pdf/29062015/the Code of Criminal Procedure (Maharashtra Amendment) Act, 2006.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Code of Criminal Procedure (Maharashtra Amendment) Act, 2006</a>
                </td>
              </tr>
              <tr role="row" class="even">
                <td>
                29</td><td>2014</td><td><a href="pdf/29062015/the Dr. Babasaheb Ambedkar Technological University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Dr. Babasaheb Ambedkar Technological University Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="odd">
              <td>
                21</td><td>2014</td><td><a href="pdf/29062015/the Maharashtra (Second Supplementary) Appropriation Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra (Second Supplementary) Appropriation Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="even">
              <td>
                3</td><td>2014</td><td><a href="pdf/29062015/The Mah. (Supplementary) Appropriation Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra (Supplementary) Appropriation Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                12</td><td>2014</td><td><a href="pdf/29062015/the Maharashtra Appropriation Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Appropriation Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="even">
                <td>
                14</td><td>2014</td>
                <td><a href="pdf/29062015/The Spicer Adventist University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Spicer Adventist University Act, 2014</a>
                </td>
              </tr>
              <tr role="row" class="odd">
                <td>
                18
                </td>
              <td>2014</td>
              <td>
              <a href="pdf/29062015/the Maharashtra Village Panchayats (Amendment and Continuance) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Village Panchayats (Amendment and Continuance) Act, 2014</a>
              </td>
              </tr>
              <tr role="row" class="even">
            <td>9</td>
            <td>2015</td>
            <td><a href="pdf/29062015/Appropriation (Vote on Account) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Appropriation (Vote on Account) Act, 2015</a></td>
            </tr>
            <tr role="row" class="odd">
            <td>14</td>
            <td>2015</td>
            <td><a href="pdf/29062015/Appropriation Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Appropriation Act, 2015</a></td>
            </tr><tr role="row" class="even"><td>13</td><td>2015</td><td><a href="pdf/29062015/Municipal Corporations and the Maharashtra Municipal Councils, Nagar Panchayats and Industrial Township (Second Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Municipal Corporations and the Maharashtra Muncipal Councils, Nagar Panchayats and Industrial Townships (Second Amendment) Act, 2015</a></td></tr><tr role="row" class="odd"><td>12</td><td>2015</td><td><a href="pdf/29062015/Fire Prevention and Life Safety Measures (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Fire Prevention and Life Safety Measures (Amendment) Act, 2015</a></td></tr><tr role="row" class="even"><td>6</td><td>2015</td><td><a href="pdf/29062015/Maharashtra (Supplementary) Appropriation Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maharashtra (Supplementary) Appropriation Act, 2015 </a></td></tr><tr role="row" class="odd"><td>5</td><td>2015</td><td><a href="pdf/29062015/Animal Preservation (Amendment) Act, 1995.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maharashtra Animal Preservation (Amendment) Act, 1995 </a></td></tr><tr role="row" class="even"><td>8</td><td>2015</td><td><a href="pdf/29062015/Universities (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maharashtra Universities (Amendment) Act, 2015</a></td></tr><tr role="row" class="odd"><td>7</td><td>2015</td><td><a href="pdf/29062015/Village Panchayats (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maharashtra Village Panchayats (Amendment) Act, 2015 </a></td></tr><tr role="row" class="even"><td>10</td><td>2015</td><td><a href="pdf/29062015/Municipal Corporations and the Maharashtra Municipal Councils, Nagar Panchayats and Industrial Township (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Corporations and the Maharashtra Municipal Councils, Nagar Panchayats and Industrial Townships (Amendment) Act, 2015</a></td></tr><tr role="row" class="odd"><td>11</td><td>2015</td><td><a href="pdf/29062015/Police (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Police (Amendment) Act, 2015</a></td></tr><tr role="row" class="even"><td>38</td><td>2015</td><td><a href="pdf/29062015/the Sandip University Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Sandip University Act, 2015</a></td></tr><tr role="row" class="odd"><td>3</td><td>2015</td><td><a href="pdf/29062015/the Ajeenkya DY Patil University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Ajeenkya D.Y.Patil University Act, 2014</a></td></tr><tr role="row" class="even"><td>2</td><td>2015</td><td><a href="pdf/29062015/the FLAME University Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The FLAME University Act, 2014</a></td></tr><tr role="row" class="odd"><td>25</td><td>2015</td><td><a href="pdf/29062015/The Hyderabad Abolition of Inams and Cash Grants (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Hyderabad Abolition of Inams and Cash Grants (Amendment) Act, 2015.</a></td></tr><tr role="row" class="even"><td>21</td><td>2015</td><td><a href="pdf/29062015/The Indian Forest (Maharashtra Amendment) Act, 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Indian Forest (Maharashtra Amendment) Act, 2013</a></td></tr><tr role="row" class="odd"><td>23</td><td>2015</td><td><a href="pdf/29062015/The Maharashtra (Second Supplementary) Appropriation Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra (Second Supplementary) Appropriation Act, 2015</a></td></tr><tr role="row" class="even"><td>15</td><td>2015</td><td><a href="pdf/29062015/Maharashtra (Urban Areas) Protection and Preservation of Trees (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra (Urban Areas) Protection and Preservation of Trees (Amendment) Act, 2015</a></td></tr><tr role="row" class="odd"><td>22</td><td>2015</td><td><a href="pdf/29062015/The Maharashtra Civil Courts (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Civil Courts (Amendment) Act, 2015</a></td></tr><tr role="row" class="even"><td>24</td><td>2015</td><td><a href="pdf/29062015/The Maharashtra Co-operative Societies  (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Co-operative Societies (Amendment) Act, 2015</a></td></tr><tr role="row" class="odd"><td>26</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Entertainments Duty (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Entertainments Duty (Amendment) Act, 2015.</a></td></tr><tr role="row" class="even"><td>33</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Fisheries (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Fisheries (Amendment) Act, 2015.</a></td></tr><tr role="row" class="odd"><td>19</td><td>2015</td><td><a href="pdf/29062015/Land Revenue Code (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Land Revenue Code (Amendment) Act, 2015</a></td></tr><tr role="row" class="even"><td>4</td><td>2015</td><td><a href="pdf/29062015/Land Revenue Code (Second Amendment) Act, 2012.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Land Revenue Code (Second Amendment) Act, 2012 </a></td></tr><tr role="row" class="odd"><td>27</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Land Revenue Code (Second Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Land Revenue Code (Second Amendment) Act, 2015.</a></td></tr><tr role="row" class="even"><td>30</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Marine Fishing Regulation (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Marine Fishing Services Act, 2015.</a></td></tr><tr role="row" class="odd"><td>18</td><td>2015</td><td><a href="pdf/29062015/The Maharashtra Muncipal Corporations (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Municipal Corporations (Amendment) Act, 2015</a></td></tr><tr role="row" class="even"><td>36</td><td>2015</td><td><a href="pdf/29062015/the Mumbai Municipal Corporation (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Official Languages (Amendment) Act, 2015.</a></td></tr><tr role="row" class="odd"><td>32</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Regional and Town Planning (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Regional and Town Planning (Amendment) Act, 2015.</a></td></tr><tr role="row" class="even"><td>37</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Regional and Town Planning (Second Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Regional and Town Planning (Second Amendment) Act, 2015.</a></td></tr><tr role="row" class="odd"><td>31</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Right to Public Services Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Right to Public Services Act, 2015.</a></td></tr><tr role="row" class="even"><td>20</td><td>2015</td><td><a href="pdf/29062015/The Stamp (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Stamp (Amendment) Act, 2015</a></td></tr><tr role="row" class="odd"><td>1</td><td>2015</td><td><a href="pdf/29062015/The Maharashtra State Reservation for Educationally and Socially Backward Category (ESBC) Act, 2014.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra State Reservation (of seats for admission in educational institutions in the State and for appointments or posts in the public services under the State) for Educationally and Socially Backward Category (ESBC) Act, 2014.</a></td></tr><tr role="row" class="even"><td>17</td><td>2015</td><td><a href="pdf/29062015/Tax Laws (Levy, Amendment and Validation) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Tax Laws (Levy, Amendment and Validation) Act, 2015</a></td></tr><tr role="row" class="odd"><td>28</td><td>2015</td><td><a href="pdf/29062015/the Maharashtra Unaided Private Professional Educational Institutions (Regulation of Admissions and Fees) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Unaided Private Professional Educational Institutions (Regulation of Admissions and Fees) Act, 2015.</a></td></tr><tr role="row" class="even"><td>29</td><td>2015</td><td><a href="pdf/29062015/The Maharashtra University (Temporary postponement of elections of members of university authorities and other bodies) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Universities (Temporary postponement of elector of members of university authorities and other bodies) Act, 2015.</a></td></tr><tr role="row" class="odd"><td>39</td><td>2015</td><td><a href="pdf/29062015/the MIT Art, Design and Technology University Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The MIT Art, Design and Technology University Act, 2015</a></td></tr><tr role="row" class="even"><td>34</td><td>2015</td><td><a href="pdf/29062015/the Mumbai Municipal Corporation (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Mumbai Municipal Corporation (Amendment) Act, 2015.</a></td></tr><tr role="row" class="odd"><td>16</td><td>2015</td><td><a href="pdf/29062015/the Nanded Sikh Gurudwara Sachkhand Shri Hazur Apchalnagar Sahib (Amendment) Act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Nanded Sikh Gurudwara Sachkhand Shri Huzur Apchalnagar Sahib (Amendment) Act, 2015</a></td></tr>


            <tr role="row" class="even"><td>3</td><td>1932</td><td><a href="pdf/29062015/(03) Indian Partnership Act (H-4029).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Indian Partnership Act, 1932</a></td></tr><tr role="row" class="odd"><td>4</td><td>1960</td><td><a href="pdf/29062015/(04) The Mah. Adaptation Of Law (H-4039).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">the Maharashtra Adaptation of Laws (State and Concurrent Subjects) Order, 1960.</a></td></tr><tr role="row" class="even"><td>6</td><td>1998</td><td><a href="pdf/29062015/(06) The Maha. Animal and Fishery Science Act (H 4054).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">the Maharashtra Animal and Fishery Sciences University Act, 1998.</a></td></tr><tr role="row" class="odd"><td>10</td><td>2014</td><td><a href="pdf/29062015/(12) Mah. Money Lending (Regulation) Act. 2014 (H 4192).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">the Maharashtra Money-Lending (Regulation) Act, 2014</a></td></tr><tr role="row" class="even"><td>2</td><td>1949</td><td><a href="pdf/29062015/(02) The Mah. Municipal Corporation Act (H-4062).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Municipal Corporations Act</a></td></tr><tr role="row" class="odd"><td>7</td><td>2014</td><td><a href="pdf/29062015/(07) The Mah. National Law Univercity act (H-4046).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">the Maharashtra National Law University Act, 2014</a></td></tr><tr role="row" class="even"><td>1</td><td>1948</td><td><a href="pdf/29062015/(01) The Mah. Tenency And Agriculture Land  Act (H-4024).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Tenancy and Agricultural Lands Act</a></td></tr><tr role="row" class="odd"><td>8</td><td>2013</td><td><a href="pdf/29062015/(09) The Mah. Unauthoriesd Instuture Act (H-4047).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">the Maharashtra Unauthorized Institutions and Unauthorized Courses of Study in Agriculture, Animal and Fishery Sciences, Health Sciences, Higher, Technical and Vocational Education (Prohibition) Act, 2013.</a></td></tr><tr role="row" class="even"><td>11</td><td>1999</td><td><a href="pdf/29062015/(17) Mah University of health science (H 4126).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra University of Health Sciences Act, 1998</a></td></tr><tr role="row" class="odd"><td>5</td><td>1955</td><td><a href="pdf/29062015/(05) The Protection Civil Rights Act (H-4188).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">the Protection of Civil Rights Act, 1955</a></td></tr>
            <tr role="row" class="even"><td>41</td><td>1966</td><td><a href="pdf/29062015/H_4011.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maharashtra Land Revenue Code, 1966</a></td></tr>

                <tr role="row" class="odd"><td>5</td><td>1962</td><td><a href="pdf/29062015/Maha. Act V 1962.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maharashtra Zilla Parishads and Panchayat Samitis Act, 1961</a></td></tr>
                   <tr role="row" class="even"><td>37</td><td>1966</td><td><a href="pdf/29062015/H_4023_29122015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Maharashtra Regional and Town Planning Act, 1966</a></td></tr>
                   <tr role="row" class="odd"><td>5</td><td>1908</td><td><a href="pdf/29062015/H_4026_FINAL_29122015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Code of Civil Procedure, 1908</a></td></tr>
                   <tr role="row" class="even"><td>33</td><td>1989</td><td><a href="pdf/29062015/H-4124_29122015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">The Scheduled Castes and the Scheduled Tribes (Prevention of Atrocities) Act, 1989</a></td></tr>


            <tr role="row" class="odd"><td>11</td><td>1953</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 11 of 1953, Bom Cinemas (Regu) Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Cinemas (Regu) Act, 1953.</a></td></tr>
            <tr role="row" class="even"><td>7</td><td>1867</td><td><a href="pdf/ljpdffilesact16012016/Bom. Acts 07 of 1867, District Police Act, 1867.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> District Police Act, 1867</a></td></tr>
            <tr role="row" class="odd"><td>11</td><td>1926</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act  11 of  1926, Invalidation of Hindu Ceremonial Emoluments Act,1925.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Invalidation of Hindu Ceremonial Emoluments Act,1925</a></td></tr>
            <tr role="row" class="even"><td>7</td><td>1882</td><td><a href="pdf/ljpdffilesact16012016/Bom. Acts 07 of 1882 Landing and Wharfage Fees Act, 1882.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Landing and Wharfage Fees Act, 1882</a></td></tr>
            <tr role="row" class="odd"><td>1</td><td>1831</td><td><a href="pdf/ljpdffilesact16012016/Bom.Reg. 1 of 1831, Regulation of Land Suits-Extnding Jurisdiction of Agent.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Regulation of Land Suits-Extending Jurisdiction of Agent</a></td></tr>
            <tr role="row" class="even"><td>63</td><td>1959</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 63 of 1959, Bom Repealing and Amending ACt, 1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Repealing and Amending Act, 1959</a></td></tr>
            <tr role="row" class="odd"><td>2</td><td>1980</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 02  of 1980, Sinhastha Fair Pilgrim Tax Act, 1980.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab"> Sinhastha Fair Pilgrim Tax Act, 1980</a></td></tr>
            <tr role="row" class="even"><td>5</td><td>1878</td><td><a href="pdf/ljpdffilesact16012016/Bom. Acts 05 of 1878, Abkari Act, 1878.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Abkari Act, 1878</a></td></tr>
            <tr role="row" class="odd"><td>16</td><td>1985</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 16 of 1985, Mah Abolition of Subsisting Proprietary Right to Mines and Minerals in Certain lands Act, 1985.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Abolition of Subsisting Proprietary Right to Mines and Minerals in Certain lands Act, 1985</a></td></tr>
            <tr role="row" class="even"><td>5</td><td>1827</td><td><a href="pdf/ljpdffilesact16012016/Bom.Reg. 05 of 1827, Acknowledgements of debts; Interest, Morgages.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Acknowledgements of debts; Interest, Morgages</a></td></tr>
            <tr role="row" class="odd"><td>14</td><td>1983</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 14  of 1983, Administrators-General and Official Trustees (Mah Amd) Act, 1982.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Administrators-General and Official Trustees (Maharashtra Amendment) Act, 1982</a></td></tr>
            <tr role="row" class="even"><td>28</td><td>1947</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  28  of  1947, Agricultural Destors Relief Act, 1947.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Destors Relief Act, 1947.</a></td></tr>
            <tr role="row" class="odd"><td>41</td><td>1962</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.41  of  1962, Agricultural Income Tax Act, 1962.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Income Tax Act, 1962</a></td></tr>
            <tr role="row" class="even"><td>43</td><td>1947</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  43  of  1947, Agricultural Pests and Diseases Act, 1947.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Pests and Diseases Act, 1947</a></td></tr>
            <tr role="row" class="odd"><td>23</td><td>1946</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act  23  of  1946, Ahmedabad and Surat Mun Administration Validation Act, 1946.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Ahmedabad and Surat Mun Administration Validation Act, 1946.</a></td></tr>
            <tr role="row" class="even"><td>17</td><td>1998</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.17of 1998, Animal and Fishery Sciences University Act, 1998.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Animal and Fishery Sciences University Act, 1998</a></td></tr>
            <tr role="row" class="odd"><td>81</td><td>1948</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  81  of  1948, Animal Preservation Act, 1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Animal Preservation Act, 1948.</a></td></tr>
            <tr role="row" class="even"><td>72</td><td>1954</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 72 of 1954, Animal Preservation Act, 1954.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Animal Preservation Act, 1954.</a></td></tr>
            <tr role="row" class="odd"><td>3</td><td>1865</td><td> <a href="pdf/ljpdffilesact16012016/Bom. Act 03 of 1865 Avoiding Wagers (Amd) Act, 1865.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Avoiding Wagers (Amendment) Act, 1865</a></td></tr>
            <tr role="row" class="even"><td>35</td><td>1959</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 35  of 1959, Bandhijama, Udhad and Ugadia Tenues Abolition , At, 1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bandhijama, Udhad and Ugadia Tenures Abolition Act, 1959</a></td></tr>
            <tr role="row" class="odd"><td>6</td><td>1925</td><td> <a href="pdf/ljpdffilesact16012016/Bom.Act 06  of 1925, Betting Tax Act, 1925.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Betting Tax Act, 1925</a></td></tr>
            <tr role="row" class="even"><td>4</td><td>1922</td><td> <a href="pdf/ljpdffilesact16012016/Bom.Act  04 of 1922 Bombay Creek (Extinguishment of Rights) Act, 1922.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Bombay Creek (Extinguishment of Rights) Act, 1922</a></td></tr>
            <tr role="row" class="odd"><td>18</td><td>1929</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 18 of 1929, Borstal Schools Act, 1929.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Borstal Schools Act, 1929</a></td></tr>
            <tr role="row" class="even"><td>31</td><td>1948</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  31  of  1948, Building (Control on Erection, Re-Erection and Conversion)Act, 1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Building (Control on Erection, Re-Erection and Conversion) Act, 1948.</a></td></tr>
            <tr role="row" class="odd"><td>2</td><td>1827</td><td> <a href="pdf/ljpdffilesact16012016/Bom.Reg. 02 of 1827, Caste-questions Pleaders.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Caste questions Pleaders</a></td></tr>
            <tr role="row" class="even"><td>2</td><td>1944</td><td> <a href="pdf/ljpdffilesact16012016/C.P. &amp;  Berar Act  02 of 1944, Central Provinces and Berar Regulation of Couching Act, 1944.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Central Provinces and Berar Regulation of Couching Act, 1944.</a></td></tr>
            <tr role="row" class="odd"><td>5</td><td>1957</td><td> <a href="pdf/ljpdffilesact16012016/Bom.Act 05 of 1957, Charged Expenditure Act, 1957.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Charged Expenditure Act, 1957</a></td></tr>
            <tr role="row" class="even"><td>15</td><td>1920</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 15 of 1920 City of Bombay Primary Education Act, 1920.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">City of Bombay Primary Education Act, 1920.</a></td></tr>
            <tr role="row" class="odd"><td>4</td><td>1827</td><td> <a href="pdf/ljpdffilesact16012016/Bom.Reg. 04 of 1827, Civil Courts (Law to be observed).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Civil Courts (Law to be observed)</a></td></tr>
            <tr role="row" class="even"><td>46</td><td>1956</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 46 of 1956, Maharashtra Contingency Fund Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Contingency Fund Act, 1956</a></td></tr>
            <tr role="row" class="odd"><td>24</td><td>1961</td><td><a href="pdf/ljpdffilesact16012016/co-operative societies act, 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Co-operative Societies Act, 1960</a></td></tr>
            <tr role="row" class="even"><td>29</td><td>1986</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 29 of 1986, Departmental Inquiries (Enforcement of Attendence of Witnessess and Production of Document) Act, 1986.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Departmental Inquiries (Enforcement of Attendence of Witnessess and Production of Document) Act, 1986</a></td></tr>
            <tr role="row" class="odd"><td>59</td><td>1948</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  59  of  1948 Diseases of Animals Act, 1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Diseases of Animals Act, 1948</a></td></tr>
            <tr role="row" class="even"><td>24</td><td>1998</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.24 of 1998, District Planning Committees (Constitution and Functions) Act, 1998.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">District Planning Committees (Constitution and Functions) Act, 1998</a></td></tr>
            <tr role="row" class="odd"><td>1</td><td>1923</td><td> <a href="pdf/ljpdffilesact16012016/Bom. Act  01 of 1923, Entertainments Duty Act, 1923.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Entertainments Duty Act, 1923</a></td></tr>
            <tr role="row" class="even"><td>7</td><td>1863</td><td> <a href="pdf/ljpdffilesact16012016/Bom. Act 07 of 1863, Exemptions From Land-Revenue (No.2) Act, 1863.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Exemptions From Land-Revenue (No.2) Act, 1863</a></td></tr>
            <tr role="row" class="odd"><td>8</td><td>1891</td><td><a href="pdf/ljpdffilesact16012016/Bom. Acts 8 of 1891 Indian Essements Act, 1882.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Extend Indian Essements Act, 1882</a></td></tr>
            <tr role="row" class="even"><td>22</td><td>1938</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act  22  of  1938, Forfeited Lands Registoration Act, 1936.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Forfeited Lands Registoration Act, 1936.</a></td></tr>
            <tr role="row" class="odd"><td>64</td><td>1947</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  64  of  1947, Forward Contracts Control Act, 1947.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Forward Contracts Control Act, 1947.</a></td></tr>
            <tr role="row" class="even"><td>23</td><td>1998</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.23 of 1998, Godawari Marathwada Irrigation Development Corporation Act, 1998.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Godawari Marathwada Irrigation Development Corporation Act, 1998</a></td></tr>
            <tr role="row" class="odd"><td>8</td><td>1950</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 08 of 1950, Greater Bom Laws and the Bom High Court (Decl of Limits)Act,1950.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Greater Bom Laws and the Bombay High Court (Declaration of Limits) Act,1950</a></td></tr>
            <tr role="row" class="even"><td>28</td><td>1993</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 28 of 1993, Groundwater (Regulation for Drinking Water purposes) Act, 1993.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Groundwater (Regulation for Drinking Water purposes) Act, 1993</a></td></tr>
            <tr role="row" class="odd"><td>17</td><td>1985</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 17  of 1985, High Court (Hearing of Writ Petitions By Division Bench and Abolition Of letters Patent Appeals) Act, 1986.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">High Court (Hearing of Writ Petitions By Division Bench and Abolition Of letters Patent Appeals) Act, 1986</a></td></tr>
            <tr role="row" class="even"><td>23</td><td>1866</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 23 of 1866, High Court (Letters Patent) Act, 1866.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">High Court (Letters Patent) Act, 1866</a></td></tr>
            <tr role="row" class="odd"><td>7</td><td>1866</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 07 of 1866 Hindu Heirs Relief Act, 1866.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Hindu Heirs' Relief Act, 1866</a></td></tr>
            <tr role="row" class="even"><td>3</td><td>1947</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  03  of  1947, Home Gurards Act, 1947.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Home Gurards Act, 1947.</a></td></tr>
            <tr role="row" class="odd"><td>40</td><td>1961</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 40 of  1961, Hyderabad Public Libraries (Repeal) Act, 1961.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Hyderabad Public Libraries (Repeal) Act, 1961</a></td></tr>
            <tr role="row" class="even"><td>98</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 98  of 1958, Inams (Kutch Area) Abolition Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Inams (Kutch Area) Abolition Act, 1958</a></td></tr>
            <tr role="row" class="odd"><td>33</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 33  of 1958, India Treasure Trove (Extension to the Hyderabad and Saurashtra Area of Bom State) Act, 1957.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">India Treasure Trove (Extension to the Hyderabad and Saurashtra Area of Bom State) Act, 1957</a></td></tr>
            <tr role="row" class="even"><td>1</td><td>1943</td><td><a href="pdf/ljpdffilesact16012016/Bom. Reg. 01  of  1943, Indian Tariff (Bom Application) Regulation, 1943.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Indian Tariff (Bom Application) Regulation, 1943.</a></td></tr>
            <tr role="row" class="odd"><td>16</td><td>1959</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 16  of 1959, Industrial Disputes (Bom Provision For Uniformity) Act, 1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Industrial Disputes (Bom Provision For Uniformity) Act, 1959</a></td></tr>
            <tr role="row" class="even"><td>78</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 78  of 1958, Judicial Officers Protection (Extn to Hyderabad and Saurashtra Areas of Bom State) Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Judicial Officers' Protection (Extension to Hyderabad and Saurashtra Areas of Bom State) Act, 1958</a></td></tr>
            <tr role="row" class="odd"><td>33</td><td>1997</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.33  of 1997, Kavi Kulaguru Kalidas Sanskrit Vishvavidyalaya (University) Act, 1997.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Kavi Kulaguru Kalidas Sanskrit Vishvavidyalaya (University) Act, 1997</a></td></tr>
            <tr role="row" class="even"><td>72</td><td>1948</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  72  of  1948, Khar Lands Act, 1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Khar Lands Act, 1948.</a></td></tr>
            <tr role="row" class="odd"><td>7</td><td>1983</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 07  of 1983, Kidney Transplantation Act, 1982.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Kidney Transplantation Act, 1982</a></td></tr>
            <tr role="row" class="even"><td>3</td><td>1998</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.03 of 1998, Konkan Irrigation Development Corporation Act, 1997 (2).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Konkan Irrigation Development Corporation Act, 1997</a></td></tr>
            <tr role="row" class="odd"><td>41</td><td>1959</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 41 of 1959, Land Revenue Code(Extn to Saurashtra Area) Act, 1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Revenue Code(Extn to Saurashtra Area) Act, 1959</a></td></tr>
            <tr role="row" class="even"><td>49</td><td>1956</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 49 of 1956, Maha Legislature Members Salaries and Allowances Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Legislature Members Salaries and Allowances Act</a></td></tr><tr role="row" class="odd">
            <td>39</td><td>1959</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 39 of 1959, Lepers (Bom Unification) Act, 1959.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Lepers (Bom Unification) Act, 1959</a></td></tr>
            <tr role="row" class="even"><td>23</td><td>1950</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 23  of 1950, Local Authorities Census Expenses Contribution Act, 1950.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Local Authorities Census Expenses Contribution Act, 1950</a></td></tr>
            <tr role="row" class="odd"><td>61</td><td>1949</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 61  of 1949, Maleki Tenure Abolition Act, 1949.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maleki Tenure Abolition Act, 1949</a></td></tr>
            <tr role="row" class="even"><td>15</td><td>1997</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 15.  of 1997, Maritime Board Act, 1996.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Maritime Board Act, 1996</a></td></tr>
            <tr role="row" class="odd"><td>15</td><td>2003</td><td><a href="pdf/ljpdffilesact16012016/Mah. Act 15 of  2003.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Medical and Dental Colleges Admissions (Regulation and Abolition of All India Quota) Act, 2003</a></td></tr>
            <tr role="row" class="even"><td>43</td><td>1953</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 43 of 1953, Merged Terriries (Ankadia Tenure Abolition)Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Merged Territories (Ankadia Tenure Abolition)Act, 1953.</a></td></tr>
            <tr role="row" class="odd"><td>45</td><td>1953</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 45 of 1953, Merged Terrotories (Baroda Mulgiras Tenure Abolition) Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Merged Territories (Baroda Mulgiras Tenure Abolition) Act, 1953.</a></td></tr>
            <tr role="row" class="even"><td>46</td><td>1953</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 46 of 1953, Merged Terrotiories (Baroda Watan Abolition) Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Merged Territories (Baroda Watan Abolition) Act, 1953.</a></td></tr>
            <tr role="row" class="odd"><td>48</td><td>1953</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 48 of 1953, Merged Territories Matadar Tenure Abolition Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Merged Territories Matadar Tenure Abolition Act, 1953.</a></td></tr>
            <tr role="row" class="even"><td>5</td><td>1999</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 05 of  1999 Metropolitan Planning Commitees (Constitutions and Functions)(Continuance of Provisions) Act, 1999.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Metropolitan Planning Commitees (Constitutions and Functions)(Continuance of Provisions) Act, 1999</a></td></tr>
            <tr role="row" class="odd"><td>22</td><td>1827</td><td><a href="pdf/ljpdffilesact16012016/Bom.Reg. 22 of 1827, Militiary Authority (Assistant to Marching Troops).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Military Authority (Assistant to Marching Troops)</a></td></tr>
            <tr role="row" class="even"><td>15</td><td>1876</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 15 of  1876 Municipal Debentures Act, 1876.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Debentures Act, 1876</a></td></tr>
            <tr role="row" class="odd"><td>1</td><td>1898</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 01 of 1898, Municipal Investments Act, 1898.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Investments Act, 1898</a></td></tr>
            <tr role="row" class="even"><td>54</td><td>1950</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 54 of 1950, Bom National Parks Act,1950.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">National Parks Act,1950</a></td></tr>
            <tr role="row" class="odd"><td>23</td><td>1936</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act  23  of  1936, Parsi Public Trusts Registration Act, 1936.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Parsi Public Trusts Registration Act, 1936.</a></td></tr>
            <tr role="row" class="even"><td>17</td><td>1920</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 17 of 1920 Pleaders Act, 1920.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Pleaders Act, 1920.</a></td></tr>
            <tr role="row" class="odd"><td>29</td><td>1997</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 29 of  1997 Maharashtra Pre-School Centres (Regulation of Admission) Act,1997.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Pre-School Centres (Regulation of Admission) Act,1997</a></td></tr>
            <tr role="row" class="even"><td>42</td><td>1949</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 42  of 1949, Prevention of Excommunication Act, 1949.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Excommunication Act, 1949</a></td></tr>
            <tr role="row" class="odd"><td>16</td><td>1970</td><td><a href="pdf/ljpdffilesact16012016/Mah. Act  16  of  1970 Maharashtra Preventation of Waer Pollution Act, 1969.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Water Pollution Act, 1969</a></td></tr>
            <tr role="row" class="even"><td>61</td><td>1947</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  61  of  1947 Primary Education Act, 1947.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Primary Education Act, 1947</a></td></tr>
            <tr role="row" class="odd"><td>58</td><td>1981</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 58  of 1981, Private Security Guards.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Private Security Guards (Regulaltion of Employment and Welfare) Act, 1981</a></td></tr>
            <tr role="row" class="even"><td>32</td><td>1989</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act  32 of 1989 Project Affected persons Rehabilitation Act, 1986.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Project Affected persons Rehabilitation Act, 1986</a></td></tr>
            <tr role="row" class="odd"><td>16</td><td>2000</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 16 of 2000 Protection of Interest of Depositors (in Financial Establishments) Act, 1999 Maharashtra.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Protection of Interest of Depositors (in Financial Establishments) Act, 1999 </a></td></tr>
            <tr role="row" class="even"><td>2</td><td>1887</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 02 of 1887 Protection of Pilgrims Act, 1887.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Protection of Pilgrims Act, 1887</a></td></tr>
            <tr role="row" class="odd"><td>5</td><td>1883</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 05 of 1883 Public Authorities Seals Act, 1883.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Public Authorities Seals Act, 1883</a></td></tr>
            <tr role="row" class="even"><td>3</td><td>1912</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 03 of 1912, Race-Courses Licensing Act, 1912.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Race-Courses Licensing Act, 1912.</a></td></tr>
            <tr role="row" class="odd"><td>5</td><td>1954</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 05 of 1954, Registration of Marriages Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Registration of Marriages Act, 1953.</a></td></tr>
            <tr role="row" class="even"><td>7</td><td>1865</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 07  of 1865 Religious Endowments (Extension to Kanara) Act, 1865.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Religious Endowments (Extension to Kanara) Act, 1865</a></td></tr>
            <tr role="row" class="odd"><td>18</td><td>2000</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 18  of 2000 Rent Control Act,1999- Maharashtra.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Rent Control Act,1999</a></td></tr>
            <tr role="row" class="even"><td>11</td><td>1852</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  11 of 1852, Rent-Free Estates Act, 1852.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Rent-Free Estates Act, 1852</a></td></tr>
            <tr role="row" class="odd"><td>21</td><td>1954</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 21 of 1954, Repealing and Amending Act, 1954.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Repealing and Amending Act, 1954.</a></td></tr>
            <tr role="row" class="even"><td>29</td><td>1955</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 29  of 1955 Bom (sec) Repealing and Amending Act, 1955.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Repealing and Amending Act, 1955</a></td></tr>
            <tr role="row" class="odd"><td>56</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 56  of 1958, Requisitioned Property(Continuance of Powers) (Saurashtra) Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Requisitioned Property (Continuance of Powers) (Saurashtra) Act, 1958</a></td></tr>
            <tr role="row" class="even"><td>10</td><td>1876</td><td><a href="pdf/ljpdffilesact16012016/Bom act 10 of 1876, Revneue Jurisdiction Act, 1876.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Revneue Jurisdiction Act, 1876</a></td></tr>
            <tr role="row" class="odd"><td>2</td><td>1951</td><td><a href="pdf/ljpdffilesact16012016/Bom.Reggulation  02 of 1951.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Secondary School Certificate Examination Act (Application to Scheduled Areas), Regulation, 1951</a></td></tr>
            <tr role="row" class="even"><td>97</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 97  of 1958, Separation of Judicial and Executive Function (Extn) and the code of Criminal Procedure (Pro for Uniformity) Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Separation of Judicial and Executive Function (Extn) and the code of Criminal Procedure (Pro for Uniformity) Act, 1958</a></td></tr>
            <tr role="row" class="odd"><td>23</td><td>1951</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 23 of 1951, Separation of Judicial and Executive Function Act, 1951.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Separation of Judicial and Executive Function Act, 1951.</a></td></tr>
            <tr role="row" class="even"><td>79</td><td>1948</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  79  of  1948, Shops and Establishments Act, 1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Shops and Establishments Act, 1948.</a></td></tr>
            <tr role="row" class="odd"><td>26</td><td>1965</td><td><a href="pdf/ljpdffilesact16012016/Mah. Act  26  of  1965 The Sir Cowasjee Jehangir Baronetcy (Repealing) Act, 1964.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Sir Cowasjee Jehangir Baronetcy (Repealing) Act, 1964</a></td></tr>
            <tr role="row" class="even"><td>32</td><td>1976</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 32  of 1976, Special Provision for Payment of Court-Fees Act, 1976.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Special Provision for Payment of Court-Fees Act, 1976</a></td></tr>
            <tr role="row" class="odd"><td>33</td><td>1974</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act  33   of 1974, Special Provision for Payment of Stamp Duty Acts, 1974.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Special Provision for Payment of Stamp Duty Act, 1974</a></td></tr>
            <tr role="row" class="even"><td>60</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 60  of 1958, Stamp Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Stamp Act, 1958</a></td></tr>
            <tr role="row" class="odd"><td>33</td><td>2001</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 33 of  2001 Maharashtra State Enterprises (Restructuring and Other Special Provisions) Act, 2000.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Enterprises (Restructuring and Other Special Provisions) Act, 2000</a></td></tr>
            <tr role="row" class="even"><td>21</td><td>1965</td><td><a href="pdf/ljpdffilesact16012016/Mah. Act  21  of  1965 Bombay State Guarantees Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Guarantees (Repeal) Act, 1964</a></td></tr>
            <tr role="row" class="odd"><td>38</td><td>1951</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 38 of 1951, State Reserve Police Force Act, 1951.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Reserve Police Force Act, 1951.</a></td></tr>
            <tr role="row" class="even"><td>83</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 83  of 1958, Bom State Scarcity Relief Fund Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Scarcity Relief Fund Act, 1958</a></td></tr>
            <tr role="row" class="odd"><td>2</td><td>1864</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act 02 of 1864, Steam-Vesels Act, 1864.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Steam-Vesels Act, 1864</a></td></tr>
            <tr role="row" class="even"><td>82</td><td>1948</td><td><a href="pdf/ljpdffilesact16012016/Bom. Act  82  of  1948, Bombay Sugarcane Cess Act, 1948.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Sugarcane Cess Act, 1948</a></td></tr>
            <tr role="row" class="odd"><td>4</td><td>1998</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.04 of 1998, Tapi Irrigation Development Corporation Act, 1997.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tapi Irrigation Development Corporation Act, 1997</a></td></tr>
            <tr role="row" class="even"><td>33</td><td>1962</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.33 of  1962, Tax on Goods (Carried by Road) Act, 1962.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on Goods (Carried by Road) Act, 1962</a></td></tr>
            <tr role="row" class="odd"><td>21</td><td>1974</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act  21  of 1974, Tax on Luxries (In Hotels and Lodging Houses) Act, 1974.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on Luxuries (In Hotels and Lodging Houses) Act, 1974</a></td></tr>
            <tr role="row" class="even"><td>19</td><td>1974</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act  19  of 1974, Tax on Residential Premises Act, 1974.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on Residential Premises Act, 1974</a></td></tr>
            <tr role="row" class="odd"><td>4</td><td>2003</td><td><a href="pdf/ljpdffilesact16012016/Mah. Act 04  of  2003 Maharashtra Tax on The Entry of Goods Into Local Areas Act, 2002.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax on The Entry of Goods Into Local Areas Act, 2002</a></td></tr>
            <tr role="row" class="even"><td>99</td><td>1958</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 99  of 1958, Tenancy and Agriculture Lands (Vidharbah Region) Act, 1958.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tenancy and Agriculture Lands (Vidharbah Region) Act, 1958</a></td></tr>
            <tr role="row" class="odd"><td>31</td><td>1997</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.31  of 1997, Truck Terminal (Reg of Location) Act, 1995.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Truck Terminal (Reg of Location) Act, 1995</a></td></tr>
            <tr role="row" class="even"><td>10</td><td>1999</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 10  of 1999 University of Healty Sciences Act, 1998.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">University of Health Sciences Act, 1998</a></td></tr>
            <tr role="row" class="odd"><td>40</td><td>1962</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.40  of  1962, Urban Immovable Property Tax (Abolition) and General Tax (Increase of Maximum Rate) Act, 1962.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Urban Immovable Property Tax (Abolition) and General Tax (Increase of Maximum Rate) Act, 1962</a></td></tr>
            <tr role="row" class="even"><td>9</td><td>2005</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 09  of 2005 Maharashtra Value Added Tax Act, 2002.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Value Added Tax Act, 2005</a></td></tr>
            <tr role="row" class="odd"><td>44</td><td>1971</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 44 of 1971, Veterinary Practioners Act, 1971.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Veterinary Practioners Act, 1971</a></td></tr>
            <tr role="row" class="even"><td>68</td><td>1953</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 68 of 1953, Veterinary Practitioners Act, 1953.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Veterinary Practitioners Act, 1953.</a></td></tr>
            <tr role="row" class="odd"><td>48</td><td>1971</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act 48  of 1971, Vexatious Litigation (Prevention) Act, 1971.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Vexatious Litigation (Prevention) Act, 1971</a></td></tr>
            <tr role="row" class="even"><td>26</td><td>1997</td><td><a href="pdf/ljpdffilesact16012016/Mah.Act.26  of 1997, Vidarbha Irrigation Development Corporation Act, 1997.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Vidarbha Irrigation Development Corporation Act, 1997</a></td></tr>
            <tr role="row" class="odd"><td>62</td><td>1950</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 62 of 1950, Bom. Watwa Vazifdari Rights Abolition Act,1950.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Watwa Vazifdari Rights Abolition Act,1950</a></td></tr>
            <tr role="row" class="even"><td>15</td><td>1932</td><td><a href="pdf/ljpdffilesact16012016/Bom.Act 15 of 1932, Weight and measures Act, 1932.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Weight and measures Act, 1932.</a></td></tr>
            <tr role="row" class="odd"><td>1</td><td>1949</td><td><a href="pdf/ljpdffilesact16012016/Bom.Reggulation  01 of 1949.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">West Khandesh Mehwassi Estates Regulation, 1949</a></td></tr>
            <tr role="row" class="even"><td>24</td><td>1951</td><td><a href="pdf/ljpdffilesact16012016/Bom.  Act 24 of 1951, Wild Animal and Wild Birds Protection Act, 1951.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Wild Animal and Wild Birds Protection Act, 1951.</a></td></tr>
            <tr role="row" class="odd"><td>46</td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/Advocate Welfare Fund Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Advocates Welfare Fund (Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="even"><td>40</td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/Factories Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Factories (Maharashtra Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="odd"><td>3</td><td>1888</td><td><a href="pdf/ljpdffilesact16012016/H-4094 The Mumbai Municipal Corporation Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Mumbai Municipal Corporation Act</a></td></tr>
            <tr role="row" class="even"><td>43</td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/Municipal Corporations and Councils.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Corporations and the Maharashtra Municipal Councils, Nagar Panchayats and Industrial Townships (Third Amendment) Act, 2015 </a></td></tr>
            <tr role="row" class="odd"><td>45</td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/National Law University.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">National Law University (Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="even"><td>4</td><td>2016</td><td><a href="pdf/ljpdffilesact16012016/Orphanages and Other Charitable Home.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Orphanages and Other Charitable Homes (Supervision and Control) the Persons with Disabilities (Equal Opportunities, Protection of Rights and Full Participation) and the Building and Other Construction Workers (Regulation of Employment and Conditions of Se</a></td></tr>
            <tr role="row" class="odd"><td>2</td><td>2016</td><td><a href="pdf/ljpdffilesact16012016/Prevention of Fragmentation and Consolidation of Holdings Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prevention of Fragmentation and Consolidation of Holdings (Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="even"><td>42</td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/MRTP.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Regional and Town Planning (Third Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="odd"><td>3</td><td>2016</td><td><a href="pdf/ljpdffilesact16012016/State Public Services.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">State Public Services [Reservation for Scheduled Castes, Scheduled Tribes, De-notified Tribes (Vimukta Jatis), Nomadic Tribes, Special Backward Category and Other Backward Classes] (Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="even"><td>1</td><td>2016</td><td><a href="pdf/ljpdffilesact16012016/Tenancy and Agricultural Lands Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tenancy and Agricultural Lands, Hyderabad Tenancy and Agricultural Lands and Maharashtra Tenancy and Agricultural Lands (Vidarbha Region) (Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="odd"><td>44</td><td>2015</td><td><a href="pdf/ljActs/University Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Universities (Second Amendment) Act, 2015</a></td></tr>
            <tr role="row" class="even"><td></td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/Errata Welfare Fund Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Advocates Welfare Fund (Amendment) Act, 2015 (Erratum)</a></td></tr>
            <tr role="row" class="odd"><td></td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/Errata Tenancy and Agricultural Lands Act.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tenancy and Agricultural Lands, Hyderabad Tenancy and Agricultural Lands and Maharashtra Tenancy and Agricultural Lands (Vidarbha Region) (Amendment) Act, 2015 (Erratum)</a></td></tr>
            <tr role="row" class="even"><td></td><td>2012</td><td><a href="pdf/ljpdffilesact16012016/List of Act  2012.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Act List of 2012</a></td></tr>
            <tr role="row" class="odd"><td></td><td>2013</td><td><a href="pdf/ljpdffilesact16012016/List of Act 2013.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Act List of 2013</a></td></tr>
            <tr role="row" class="even"><td></td><td>2014</td><td><a href="pdf/ljpdffilesact16012016/Supply of Act List 2014 with letter.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Act List of 2014</a></td></tr>
            <tr role="row" class="odd"><td></td><td>2015</td><td><a href="pdf/ljpdffilesact16012016/List of Act 2015.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Act List of 2015</a></td></tr>

     <tr role="row" class="even"><td>5</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/Dangerous Activities.aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Prevention of Dangerous Activities of Slumlords, Bootleggers, Drug-offenders, Dangerous persons and video pirates (Amendment) Act, 2015</a></td></tr>
      <tr role="row" class="odd"><td>6</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/Paramedical Council Act.aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Paramedical Council Act, 2011.</a></td></tr>
       <tr role="row" class="even"><td>2</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/Co-operative societies Ordinance,2016.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Co-operative Societies (Amendment) Ordinance, 2016. </a></td></tr>
        <tr role="row" class="odd"><td>1</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/Agricultural Produce Marketing (Development and Regulation) (Amendment and Continuance) Ordinance, 2016.aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Agricultural Produce Marketing (Development and Regulation) (Amendment and Continuance) Ordinance, 2016</a></td></tr>
         <tr role="row" class="even"><td>2</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/ERRATA to Co-Operative Societies Ordinance, 2016.aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">ERRATA to Maharashtra Co-operative Societies (Amendment) Ordinance, 2016</a></td></tr>
           <tr role="row" class="odd"><td>3</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/Land Revenue Code (Amendment) Ordinance, 2016. aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Land Revenue Code (Amendment) Ordinance, 2016.</a></td></tr>
           <tr role="row" class="even"><td></td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/the Maharashtra Public Trusts (Amendment) Ordinance, 2016.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Public Trusts (Amendment) Ordinance, 2016.</a></td></tr>
            <tr role="row" class="odd"><td>12</td><td>1961</td><td><a href="pdf/ljpdfacts15_02_2016/H 4114.pmd Anicient Monuments.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">The Maharashtra Ancient Monuments and Archaeological Sites and Remains Act, 1960.</a></td></tr>
             <tr role="row" class="even"><td>5</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/the Maharashtra Co-operative.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">The Maharashtra Co-operative Societies (Second Amendment) Ordinance, 2016.</a></td></tr>
              <tr role="row" class="odd"><td>3</td><td>1874</td><td><a href="pdf/ljpdfacts15_02_2016/H_4110__The_Maha._Hereditary_Offices_Act_.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Hereditary Offices Act</a></td></tr>
               <tr role="row" class="even"><td>7</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/the Maharashtra (Supplementary) Appropriation Act, (2).pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">(Supplementary) Appropriation Act, 2016</a></td></tr>
                 <tr role="row" class="odd"><td>8</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/the Maharashtra Appropriation (Vote on.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Appropriation (Vote on Account)</a></td></tr>
                  <tr role="row" class="even"><td>9</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/the Maharashtra Public Trusts Act (1).aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Public Trusts (Amendment) Act, 2016</a></td></tr>
                    <tr role="row" class="odd"><td>10</td><td>2016</td><td><a href="pdf/ljpdfacts15_02_2016/the Maharashtra Village Panchayats.aspx.pdf" target="_blank" alt="Download PDF.pdf" title="Click here to open in new tab">Village Panchayats (Amendment) Act, 2016</a></td></tr>


            <tr role="row" class="even"><td>8</td><td>2016</td><td><a href="pdf/ljActs/Agricultural Produce Marketing (Development and Regulation).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Agricultural Produce Marketing (Development and Regulation) (Continuance) Ordinance, 2016</a></td></tr>
            <tr role="row" class="odd"><td>6</td><td>2016</td><td><a href="pdf/ljActs/Co-operative Societies (Amendment and Continuance), Ordinancce.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Co-operative Societies (Amendment and Continuance) Ordinance, 2016.</a></td></tr>
            <tr role="row" class="even"><td>7</td><td>2016</td><td><a href="pdf/ljActs/Maharashtra Co-operative Societies.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Co-operative Societies (Amendment and Second Continuance) Ordinance, 2016</a></td></tr>
            <tr role="row" class="odd"><td></td><td>2016</td><td><a href="pdf/ljActs/Errate to Ord VIII of 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Errata to Agricultural Produce Marketing (Development and Regulation) (Amendment and Second Continuance) Ordinance, 2016</a></td></tr>
            <tr role="row" class="even"><td></td><td>2016</td><td><a href="pdf/ljActs/Governor Order.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Governor Order to amend Village Panchayats Act</a></td></tr>
            <tr role="row" class="odd"><td>17</td><td>2016</td><td><a href="pdf/ljActs/Land Revenue Code Second Amendment 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Revenue Code (Second Amendment) Act, 2016</a></td></tr>
            <tr role="row" class="even"><td>12</td><td>2016</td><td><a href="pdf/ljActs/Maharashtra Prohibition of Obscene Dance in Hotels, Restaurants and Bar.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Prohibition of Obscene Dance in Hotels, Restaurants and Bar Room,s Dignity of Women (working therein) Act, 2016</a></td></tr>
            <tr role="row" class="odd"><td>16</td><td>2016</td><td><a href="pdf/ljActs/Settlement of Arrears in Disputes.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Settlement of Arrears in Disputes Act, 2016</a></td></tr>
            <tr role="row" class="even"><td>18</td><td>2016</td><td><a href="pdf/ljActs/Stamp Act 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Stamp (Amendment) Act, 2016</a></td></tr>
            <tr role="row" class="odd"><td>15</td><td>2016</td><td><a href="pdf/ljActs/Tax Laws 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tax Laws (Levy, Amendment and Validation)  Act, 2016</a></td></tr>
            <tr role="row" class="even"><td>14</td><td>2016</td><td><a href="pdf/ljActs/Maharashtra Water Conservation Corporation.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Water Conservation Corporation (Amendment) Act, 2016</a></td></tr>
            <tr role="row" class="odd"><td>13</td><td>2016</td><td><a href="pdf/ljActs/Maharashtra Appropriation Act,  2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Appropriation Act, 2016</a></td></tr>


             <tr role="row" class="even"><td>11</td><td>2016</td><td><a href="pdf/ljActs/Land Revenue Code  Amendment 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Land Revenue Code ( Amendment) Act, 2016 </a></td></tr>


             <tr role="row" class="odd"><td>19</td><td>2016</td><td><a href="pdf/ljActs/Municipal Corporations and the Maharashtra Municipal Councils, Nagar Panchayat (fourth amendment).pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Municipal Corporations and the Maharashtra Municipal Councils, Nagar Panchayat (fourth amendment) Act, 2015 </a></td></tr>

             <tr role="row" class="even"><td>20</td><td>2016</td><td><a href="pdf/ljActs/XX of 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Tenancy and Agricultural Lands, the Hyderabad Tenancy and Agricultural Lands and the Maharashtra Tenancy and Agricultural Lands (Vidarbha Region) (Second Amendment) Act, 2016 </a></td></tr>

             <tr role="row" class="odd"><td>21</td><td>2016</td><td><a href="pdf/ljActs/XXI of 2016.pdf" target="_blank" alt="Download PDF" title="Click here to open in new tab">Zilla Parishads and Panchayat Samitis (Amendment) Act, 2016. </a></td></tr>

                </tbody>
            </table>
</asp:Content>
