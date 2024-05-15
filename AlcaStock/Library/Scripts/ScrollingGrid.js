/*
 * Copyright © 2005, Ashley van Gerven (ashley.v__g__@g__mail.com - remove '_')
 * All rights reserved.
 *
 * Use of this script, with or without modification, is permitted
 * provided that the above copyright notice and disclaimer below is not removed.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY
 * OF SUCH DAMAGE.
 */


var updateSGDivWidthsExplorerTimer = null


function initScrollingGrid(scrollingGridID, gridID, lastRowIsPager, startScrollLeft, startScrollTop)
{
	if (navigator.userAgent.toLowerCase().indexOf("opera") != -1) // opera not supported
		return;

	if (!document.getElementById) // old browsers not supported
		return;

	var tblHdr = document.getElementById(scrollingGridID + "$tblHdr");
	var tblDataGrid = document.getElementById(gridID);
	var tblPager = document.getElementById(scrollingGridID + "$tblPager");

	// get header table's first row
	var tbodyEl = tblHdr.childNodes[firstChildElIndex(tblHdr, "TBODY")];
	var trEl = tbodyEl.childNodes[firstChildElIndex(tbodyEl, "TR")];

	// get datagrid table's first row
	var tbodyEl2 = tblDataGrid.childNodes[firstChildElIndex(tblDataGrid, "TBODY")];
	var trEl2 = tbodyEl2.childNodes[firstChildElIndex(tbodyEl2, "TR")];

	// delete empty TR on placeholder table
	tbodyEl.removeChild(trEl);

	// move the header row from datagrid table to our placeholder table
	tbodyEl.appendChild(trEl2);

	if (lastRowIsPager)  // if grid pager is last row then move it below the scrolling DIV (i.e. freeze it)
	{
		// get pager table's first row
		var tbodyEl3 = tblPager.childNodes[firstChildElIndex(tblPager, "TBODY")];
		var trEl3 = tbodyEl3.childNodes[firstChildElIndex(tbodyEl3, "TR")];

		// get datagrid table's last row
		var trEl4 = tbodyEl2.childNodes[lastChildElIndex(tbodyEl2, "TR")];

		// delete empty TR on placeholder table
		tbodyEl3.removeChild(trEl3);

		// move the footer from datagrid table to our seperate table
		tbodyEl3.appendChild(trEl4);

		// set table width to match content DIV
		tblPager.width = document.getElementById(scrollingGridID + "$divContent").offsetWidth;
	}


	setColumnWidths(scrollingGridID, gridID);


	if (window.attachEvent)  // IE only - resize DIVs now + on resize
	{
		updateSGDivWidthsExplorer();
		window.attachEvent("onresize", scheduleUpdateSGDivWidthsExplorer);
	}
}


// match up column widths
function setColumnWidths(scrollingGridID, gridID)
{
	// reset scroll positions since FF remembers them on page-refresh
	document.getElementById(scrollingGridID + "$divHdr").scrollLeft = 0;
	document.getElementById(scrollingGridID + "$divContent").scrollLeft = 0;
	document.getElementById(scrollingGridID + "$divContent").scrollTop = 0;

	// for FF: ensure enough space to expand columns
	document.getElementById(scrollingGridID + "$headerCntr").style.width = 10000;
	document.getElementById(scrollingGridID + "$contentCntr").style.width = 10000;

	var widths = new Array();
	var totalWidth = 0;

	var tblHdr = document.getElementById(scrollingGridID + "$tblHdr");
	var tblGrid = document.getElementById(gridID);

	// get header row
	var tbodyEl = tblHdr.childNodes[firstChildElIndex(tblHdr, "TBODY")];
	var trEl = tbodyEl.childNodes[firstChildElIndex(tbodyEl, "TR")];

	// get first content row
	var tbodyEl2 = tblGrid.childNodes[firstChildElIndex(tblGrid, "TBODY")];
	var trIndex = firstChildElIndex(tbodyEl2, "TR");
	if (trIndex == -1) // i.e. no content rows
	{
		document.getElementById(scrollingGridID + "$contentCntr").style.width = 1;
		return;
	}
	var trEl2 = tbodyEl2.childNodes[trIndex];


	for (var i=0; i<trEl.childNodes.length; i++)
	{
		if (trEl.childNodes[i].nodeName != "TD") // skip #text nodes
			continue;

		// TD element for the header row
		var tdHdr = trEl.childNodes[i];

		// TD element for the content row
		var tdContent = trEl2.childNodes[i];

		// get width of of the header or content cell (depends which is widest)
		if (tdHdr.offsetWidth > tdContent.offsetWidth)
			widths[i] = tdHdr.offsetWidth;
		else
			widths[i] = tdContent.offsetWidth;

		totalWidth += widths[i];
	}


	if (document.all) // IE: set table-layout style
	{
		tblGrid.style.tableLayout = "fixed";
		tblHdr.style.tableLayout = "fixed";
	}


	for (var i=0; i<widths.length; i++)
	{
		if (widths[i]+"" == "undefined")
			continue;

		// TD element for the header row
		var tdHdr = trEl.childNodes[i];

		// TD element for the content row
		var tdContent = trEl2.childNodes[i];

		var widthAdjustment = 0;
		if (!document.all)
		{
			widthAdjustment = -2 * parseInt(tblGrid.getAttribute("cellpadding")); // FF: subtract cellpadding
		}

		// Update either the header cell or content cell (not both, otherwise FF stuffs up)
		if (tdHdr.offsetWidth != widths[i])
			tdHdr.style.width = widths[i] + widthAdjustment; // update header column width
		if (tdContent.offsetWidth != widths[i])
			tdContent.style.width = widths[i] + widthAdjustment; // update content column width
	}

	// update the content container table width from 10000 to correct width
	document.getElementById(scrollingGridID + "$contentCntr").style.width = tblGrid.offsetWidth;
}


// IE resize event handler
function scheduleUpdateSGDivWidthsExplorer()
{
	clearTimeout(updateSGDivWidthsExplorerTimer);
	updateSGDivWidthsExplorerTimer = setTimeout("updateSGDivWidthsExplorer()", 20);
}


// IE only - update widths for all ScrollingGrids according to their container table (since content of table is clipped)
function updateSGDivWidthsExplorer()
{
	var arr = document.getElementsByTagName("TABLE");
	for (i=0; i<arr.length; i++)
	{
		if (arr[i].getAttribute("NAME") == "ScrollingGrid")
		{
			var scrollingGridID = arr[i].id;

			var headerReduction = 0;
			if (document.getElementById(scrollingGridID + "$divHdr").style.marginRight != "")
				headerReduction = parseInt(document.getElementById(scrollingGridID + "$divHdr").style.marginRight);

			var footerReduction = 0;
			if (document.getElementById(scrollingGridID + "$tblPager") != null && document.getElementById(scrollingGridID + "$tblPager").style.marginRight != "")
				footerReduction = parseInt(document.getElementById(scrollingGridID + "$tblPager").style.marginRight);

			try
			{
				document.getElementById(scrollingGridID + "$divHdr").style.width = document.getElementById(scrollingGridID).clientWidth - headerReduction;
				document.getElementById(scrollingGridID + "$divContent").style.width = document.getElementById(scrollingGridID).clientWidth;
				document.getElementById(scrollingGridID + "$tblPager").style.width = document.getElementById(scrollingGridID).clientWidth - footerReduction;
			}
			catch (err)
			{}

			updateScroll(document.getElementById(scrollingGridID + "$divContent"), scrollingGridID);
		}
	}
}


// find the index of first child element (e.g. TBODY) - handy for FF which creates #text nodes from whitespace
function firstChildElIndex(el, searchFor)
{
	for (var i=0; i<el.childNodes.length; i++)
	{
		if (el.childNodes[i].nodeName == searchFor)
			return i;
	}
	return -1;
}


// find the index of last child element
function lastChildElIndex(el, searchFor)
{
	for (var i=el.childNodes.length-1; i>=0; i--)
	{
		if (el.childNodes[i].nodeName == searchFor)
			return i;
	}
	return -1;
}


// content scroll event handler (matches the header row with the horizontal scroll position of content)
function updateScroll(divObj, scrollingGridID)
{
	if (document.getElementById(scrollingGridID + "$divHdr") != null)
		document.getElementById(scrollingGridID + "$divHdr").scrollLeft = divObj.scrollLeft;

	// save scroll position to hidden input
	document.getElementById(scrollingGridID + "$hdnScrollPos").value = divObj.scrollLeft + "-" + divObj.scrollTop;
}


function setContentScrollPos(sgID, left, top)
{
	var divContent = document.getElementById(sgID + "$divContent");
	divContent.scrollLeft = left;
	divContent.scrollTop = top;
}




// ************************************
// *        Utility functions         *
// ************************************

// scale the content DIV height with the browser window height minus specified height [reduceBy]
function scaleHeightToBrowser(sgID, reduceBy, minHeight)
{
	var newHeight = document.body.clientHeight - reduceBy;
	if (newHeight < minHeight)
		newHeight = minHeight;

	document.getElementById(sgID + "$divContent").style.height = newHeight;
}


// scroll the content by cellspacing height to get rid of double border
function adjustScrollTop(scrollingGridID, gridID)
{
	document.getElementById(scrollingGridID + "$divContent").scrollTop = parseInt(document.getElementById(gridID).getAttribute("cellspacing"));
}


// reduce the height of the header div by cellspacing height to get rid of double border (alternate method to adjustScrollTop)
function cropHeader(scrollingGridID, gridID)
{
	document.getElementById(scrollingGridID + "$divHdr").style.height = document.getElementById(scrollingGridID + "$divHdr").offsetHeight - parseInt(document.getElementById(gridID).getAttribute("cellspacing"));
}
