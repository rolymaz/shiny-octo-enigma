using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TST.Models;
using TST.Data;

namespace TST.Services
{
    public class FileImport
    {

        private SalesTrackerDbEntities db = new SalesTrackerDbEntities();

        public void ImportPostVetFile(int fileId)
        {

            FileLog fileInfo = db.FileLogs.Find(fileId);

            fileInfo.StatusId = (int)ImportStatus.Complete;

            using (CsvReader csv = new CsvReader(new StreamReader(fileInfo.Filepath)))
            {
                //use a template that matches the csv file fields
                //TODO: ensure the postvet fields are all correctly mapped 

                IEnumerable<PostvetResult> imported = csv.GetRecords<PostvetResult>();

                csv.Configuration.IsHeaderCaseSensitive = false;
                csv.Configuration.TrimFields = true;
                csv.Configuration.WillThrowOnMissingField = true;

                foreach (var item in imported)
                {
                    var postvetResult = new PostvetResult
                    {

                        FileId = fileInfo.Id,
                        IDN = item.IDN,
                        ProcessDate = DateTime.Now,
                        Outcome = item.Outcome,
                        StatusId = (int)ImportStatus.New

                    };

                    db.PostvetResults.Add(postvetResult);
                    db.SaveChanges();

                }
            }

        }

        /// <summary>
        /// processes a postvet import file
        /// </summary>
        /// <param name="fileId"></param>
        public void ProcessPostVetFile(int fileId)
        {
            var PostvetQuery = from st in db.PostvetResults
                               where st.FileId == fileId
                               orderby st.Id
                               select st;


            foreach (var item in PostvetQuery)
            {

                //TODO: need a full list of postvet approval and decline reasons 

                //lookup outcome and determine the appropriate action from list

                //fire the appropriate trigger



            }
        }



        public void ImportActivationFile(int fileId)
        {
            FileLog fileInfo = db.FileLogs.Find(fileId);

            fileInfo.StatusId = (int)ImportStatus.Complete;

            using (CsvReader csv = new CsvReader(new StreamReader(fileInfo.Filepath)))
            {
                //use a template that matches the csv file fields
                //TODO: ensure the postvet fields are all correctly mapped 

                IEnumerable<ActivationResult> imported = csv.GetRecords<ActivationResult>();

                csv.Configuration.IsHeaderCaseSensitive = false;
                csv.Configuration.TrimFields = true;
                csv.Configuration.WillThrowOnMissingField = true;

                foreach (var item in imported)
                {
                    var activationResult = new ActivationResult
                    {

                        FileId = fileInfo.Id,
                        MSISDN = item.MSISDN,
                        ProcessDate = DateTime.Now,
                        Outcome = item.Outcome,
                        StatusId = (int)ImportStatus.New

                    };


                    db.ActivationResults.Add(activationResult);
                    db.SaveChanges();

                }
            }
        }

        public void ProcessActivationFile(int fileId)
        {
            var ActivationQuery = from st in db.ActivationResults
                                  where st.FileId == fileId
                                  orderby st.Id
                                  select st;


            foreach (var item in ActivationQuery)
            {

                //TODO: lookup up the record from the activtion report - based on MSSDN and fire off passactivation




            }

        }



    }
}