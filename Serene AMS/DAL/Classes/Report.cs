using iTextSharp.text;
using iTextSharp.text.pdf;
using Serene_AMS.ViewModels;
using Serene_AMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Serene_AMS.DAL.Classes
{
    public class Report
    {
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        Font _fontStyleNotBold;
      
        PdfPTable _pdfgrTable = new PdfPTable(4);
        PdfPTable _pdfTable = new PdfPTable(4);
        PdfPTable _pdfprTable = new PdfPTable(4);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        ProcureVM _procure = new ProcureVM();



        public byte[] PreparePRReport(ProcureVM procure)
        {
            _procure = procure;

            _document = new Document(PageSize.A4, 0f, 0f, 1f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfprTable.WidthPercentage = 100;
            _pdfprTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfprTable.SetWidths(new float[] { 20f, 150f, 100f,50f });

            this.ReportPRHeader();
            this.ReportPRBody();
            _pdfprTable.HeaderRows = 2;
            _document.Add(_pdfprTable);
            _document.Close();
            return _memoryStream.ToArray();


        }
        private void ReportPRHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Purchase Request", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 1;
            _pdfprTable.AddCell(_pdfPCell);
            _pdfprTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serene Air Engineering Services", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfprTable.AddCell(_pdfPCell);
            _pdfprTable.CompleteRow();
        }
        private void ReportPRBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _fontStyleNotBold = FontFactory.GetFont("Tahoma", 12f, 0);

            _pdfPCell = new PdfPCell(PRLeftDetails());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfprTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(PRRightDetail());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfprTable.AddCell(_pdfPCell);
            _pdfprTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sr no", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfprTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfprTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Ordered Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfprTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Price", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfprTable.AddCell(_pdfPCell);
            _pdfprTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            foreach (ProcureVM procure in _procure.IRDetails)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfprTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfprTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.Quantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfprTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.Total.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfprTable.AddCell(_pdfPCell);


                _pdfprTable.CompleteRow();
            }


        }
        private PdfPTable PRLeftDetails()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            _pdfPCell = new PdfPCell(new Phrase("Company:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Serene Air Pvt Lmd", _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Document No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Grno, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created on:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdon.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdby, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Vendor:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.VendorName, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();
            opdfPTable.SpacingBefore = 20f;
            opdfPTable.SpacingAfter = 30f;

            return opdfPTable;
        }

        private PdfPTable PRRightDetail()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            opdfPTable.SpacingBefore = 30f;
            _pdfPCell = new PdfPCell(new Phrase("Generated by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();

            _pdfPCell = new PdfPCell(new Phrase(user, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Generated Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var date = DateTime.Now.Date;
            _pdfPCell = new PdfPCell(new Phrase(date.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Requested Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
           
            _pdfPCell = new PdfPCell(new Phrase(_procure.RequestedDate.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

           



            return opdfPTable;
        }
        public byte[] PreparePOReport(ProcureVM procure)
        {
            _procure = procure;

            _document = new Document(PageSize.A4, 0f, 0f, 1f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f,50f });

            this.ReportPOHeader();
            this.ReportPOBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();


        }
        private void ReportPOHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Purchase Order", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 1;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serene Air Engineering Services", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
        private void ReportPOBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _fontStyleNotBold = FontFactory.GetFont("Tahoma", 12f, 0);

            _pdfPCell = new PdfPCell(POLeftDetails());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(PORightDetail());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sr no", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Ordered Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Item Price", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            foreach (ProcureVM procure in _procure.IRDetails)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.Quantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.Total.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);


                _pdfTable.CompleteRow();
            }


        }
        private PdfPTable POLeftDetails()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            _pdfPCell = new PdfPCell(new Phrase("Company:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Serene Air Pvt Lmd", _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Document No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Grno, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created on:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdon.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdby, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Vendor:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.VendorName, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();
            opdfPTable.SpacingBefore = 20f;
            opdfPTable.SpacingAfter = 30f;

            return opdfPTable;
        }

        private PdfPTable PORightDetail()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            opdfPTable.SpacingBefore = 30f;
            _pdfPCell = new PdfPCell(new Phrase("Generated by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();

            _pdfPCell = new PdfPCell(new Phrase(user, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Generated Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var date = DateTime.Now.Date;
            _pdfPCell = new PdfPCell(new Phrase(date.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Requested Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.RequestedDate.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Delivery Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.DeliveryDate.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("PR Reference No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Prreferenceno.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            return opdfPTable;
        }
        public byte[] PrepareReport(ProcureVM procure)
        {
            _procure = procure;

            _document = new Document(PageSize.A4, 0f, 0f, 1f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfgrTable.WidthPercentage = 100;
            _pdfgrTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfgrTable.SetWidths(new float[] { 20f, 150f, 100f,50f });

            this.ReportGRHeader();
            this.ReportGRBody();
            _pdfgrTable.HeaderRows = 2;
            _document.Add(_pdfgrTable);
            _document.Close();
            return _memoryStream.ToArray();


        }
      
        private void ReportGRHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Goods Receipt", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 1;
            _pdfgrTable.AddCell(_pdfPCell);
            _pdfgrTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serene Air Engineering Services", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfgrTable.AddCell(_pdfPCell);
            _pdfgrTable.CompleteRow();
        }
        private void ReportGRBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _fontStyleNotBold = FontFactory.GetFont("Tahoma", 12f, 0);
           
            _pdfPCell = new PdfPCell(GRDetails());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfgrTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(Detail());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfgrTable.AddCell(_pdfPCell);
            _pdfgrTable.CompleteRow();

          
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sr no", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Type", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);
           

            _pdfPCell = new PdfPCell(new Phrase("Delivered Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);

            
            _pdfgrTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            foreach (ProcureVM procure in _procure.GRDetails)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(procure.ItemType, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.DeliveredQuantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);                
                _pdfgrTable.CompleteRow();
            }


        }
        private PdfPTable GRDetails()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });

            _pdfPCell = new PdfPCell(new Phrase("Company:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Serene Air Pvt Lmd", _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Document No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Grno, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created on:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdon.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdby, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Vendor:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.VendorName, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();
            opdfPTable.SpacingBefore = 20f;
            opdfPTable.SpacingAfter = 30f;
           
            return opdfPTable;
        }

        private PdfPTable Detail()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });

            opdfPTable.SpacingBefore = 30f;
            _pdfPCell = new PdfPCell(new Phrase("Generated by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();

            _pdfPCell = new PdfPCell(new Phrase(user,_fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Generated Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            
            _pdfPCell = new PdfPCell(new Phrase(_procure.GeneratedDate.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("PO Reference No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Poreferenceno.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            return opdfPTable;
        }
        public byte[] PrepareGRReportForR(ProcureVM procure)
        {
            _procure = procure;

            _document = new Document(PageSize.A4, 0f, 0f, 1f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfgrTable.WidthPercentage = 100;
            _pdfgrTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfgrTable.SetWidths(new float[] { 20f, 150f, 100f, 50f });

            this.ReportGRHeaderforR();
            this.ReportGRBodyforR();
            _pdfgrTable.HeaderRows = 2;
            _document.Add(_pdfgrTable);
            _document.Close();
            return _memoryStream.ToArray();


        }

        private void ReportGRHeaderforR()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Goods Receipt", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 1;
            _pdfgrTable.AddCell(_pdfPCell);
            _pdfgrTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serene Air Engineering Services", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfgrTable.AddCell(_pdfPCell);
            _pdfgrTable.CompleteRow();
        }
        private void ReportGRBodyforR()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _fontStyleNotBold = FontFactory.GetFont("Tahoma", 12f, 0);

            _pdfPCell = new PdfPCell(GRDetailsforR());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfgrTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(DetailforR());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfgrTable.AddCell(_pdfPCell);
            _pdfgrTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sr no", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Type", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Delivered Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfgrTable.AddCell(_pdfPCell);


            _pdfgrTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            foreach (ProcureVM procure in _procure.GRDetails)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(procure.ItemType, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.DeliveredQuantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfgrTable.AddCell(_pdfPCell);
                _pdfgrTable.CompleteRow();
            }


        }
        private PdfPTable GRDetailsforR()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });

            _pdfPCell = new PdfPCell(new Phrase("Company:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Serene Air Pvt Lmd", _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Document No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Grno, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created on:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdon.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdby, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Vendor:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.VendorName, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();
            opdfPTable.SpacingBefore = 20f;
            opdfPTable.SpacingAfter = 30f;

            return opdfPTable;
        }

        private PdfPTable DetailforR()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });

            opdfPTable.SpacingBefore = 30f;
            _pdfPCell = new PdfPCell(new Phrase("Generated by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();

            _pdfPCell = new PdfPCell(new Phrase(user, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Generated Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.GeneratedDate.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Return Reference No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.returnref.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            return opdfPTable;
        }
        public byte[] PrepareReturnReport(ProcureVM procure)
        {
            _procure = procure;

            _document = new Document(PageSize.A4, 0f, 0f, 1f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f, 50f });

            this.ReportReturnHeader();
            this.ReportReturnBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();


        }
        private void ReportReturnHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Return Delivery", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 1;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serene Air Engineering Services", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
        private void ReportReturnBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _fontStyleNotBold = FontFactory.GetFont("Tahoma", 12f, 0);

            _pdfPCell = new PdfPCell(RDetails());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(ReturnDetail());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sr no", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Delivered Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Quantity to Return", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            foreach (ProcureVM procure in _procure.IRDetails)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.DeliveredQuantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.RejectedQuantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }


        }
        private PdfPTable RDetails()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            _pdfPCell = new PdfPCell(new Phrase("Company:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Serene Air Pvt Lmd", _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Document No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Grno, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created on:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdon.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdby, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Vendor:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.VendorName, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Reason of Return:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Reasonofreturn, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();
            opdfPTable.SpacingBefore = 20f;
            opdfPTable.SpacingAfter = 30f;

            return opdfPTable;
        }

        private PdfPTable ReturnDetail()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            opdfPTable.SpacingBefore = 30f;
            _pdfPCell = new PdfPCell(new Phrase("Generated by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();

            _pdfPCell = new PdfPCell(new Phrase(user, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Generated Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var date = DateTime.Now.Date;
            _pdfPCell = new PdfPCell(new Phrase(date.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("GR Reference No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            
            _pdfPCell = new PdfPCell(new Phrase(_procure.grref.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();



            return opdfPTable;
        }
        public byte[] PrepareIRReport(ProcureVM procure)
        {
            _procure = procure;

            _document = new Document(PageSize.A4, 0f, 0f, 1f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f, 50f });

            this.ReportIRHeader();
            this.ReportIRBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();


        }
        private void ReportIRHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Invoice Receipt", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 1;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serene Air Engineering Services", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
        private void ReportIRBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _fontStyleNotBold = FontFactory.GetFont("Tahoma", 12f, 0);

            _pdfPCell = new PdfPCell(IRDetails());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(StatusDetail());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sr no", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Delivered Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Item Price", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            int serialNumber = 1;
            foreach (ProcureVM procure in _procure.IRDetails)
            {
                _pdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.DeliveredQuantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(procure.ItemPrice.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }


        }
        private PdfPTable IRDetails()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            _pdfPCell = new PdfPCell(new Phrase("Company:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Serene Air Pvt Lmd", _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Document No:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Grno, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created on:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdon.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Created by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Createdby, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Vendor:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.VendorName, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();
            opdfPTable.SpacingBefore = 20f;
            opdfPTable.SpacingAfter = 30f;

            return opdfPTable;
        }

        private PdfPTable StatusDetail()
        {
            PdfPTable opdfPTable = new PdfPTable(2);
            opdfPTable.SetWidths(new float[] { 100f, 100f });


            opdfPTable.SpacingBefore = 30f;
            _pdfPCell = new PdfPCell(new Phrase("Generated by:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var user = System.Web.HttpContext.Current.Session["UserName"].ToString();

            _pdfPCell = new PdfPCell(new Phrase(user, _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Generated Date:", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            var date = DateTime.Now.Date;
            _pdfPCell = new PdfPCell(new Phrase(date.ToString("dd-MMM-yyyy"), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Total Amount", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Total.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Paid Amount", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Paid.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Balance", _fontStyle));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_procure.Balance.ToString(), _fontStyleNotBold));
            _pdfPCell.Border = 0;
            opdfPTable.AddCell(_pdfPCell);
            opdfPTable.CompleteRow();

            return opdfPTable;
        }
    }
}