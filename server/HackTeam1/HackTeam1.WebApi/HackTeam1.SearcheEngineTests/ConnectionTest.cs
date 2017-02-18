﻿using System.Linq;
using HackTeam1.Entities;
using HackTeam1.SearchEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackTeam1.SearcheEngineTests
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void TestConnection()
        {

            var testEntity = new Document()
            {
                Category = "bla bla",
                MimeType = "docx",
                Title = "Invoiceee",
                Text = "heello world",
                OcrFileName = "C:/departe",
            };

            var elastic = new ElasticConnector();

            elastic.Index(testEntity);

            var myData=  elastic.GetData();

            Assert.AreEqual("bla bla", myData.Category);
        }

        [TestMethod]
        public void TestDocument2()
        {
            var testEntity = new Document()
            {
                Category = "bla bla",
                MimeType = "docx",
                Title = "Invoice1234",
                Text = "heello world",
                OcrFileName = "C:/departe",
            };


            var elastic = new ElasticConnector();

            elastic.Index(testEntity);

            var myData = elastic.GetData();

            Assert.AreEqual("Invoice1234", myData.Title);
        }

        
    }
}