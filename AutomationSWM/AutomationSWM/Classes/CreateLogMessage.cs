﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationSWM
{
    public enum STATUS { PASS,FAIL}
    public enum ACTION { Add_New_Software, Add_New_USER , Add_New_Vehicle , Add_New_Campaign }


    public class CreateLogMessage
    {

      
        AutomationDBEntities db = new AutomationDBEntities();
        //public byte[] imageToByteArray(Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Add(ms, ImageFormat.Png);
        //    return ms.ToArray();
        //}


        public void ExceptionMessage(Exception ex, string msg ,string component_id , string host,string DT )
        {


            string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);

            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt",
                                "TEST_ID: " + DT + " ---- " + host + " -------" + msg + " -------------" + " Date :" + DateTime.Now.ToString()
                                + "----------------------------------------" +
                              Environment.NewLine + "Message :" + lineNumber +" "+ ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                      "" + Environment.NewLine);
            string New = Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine;
            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt", New);
            /*C:\Users\ravdaian\documents\visual studio 2017\Projects\AutomationTesting\SoftwareTest\Log.txt*/
            AddErrorToDB(ex, msg, component_id, host, DT);

        }

        private void AddErrorToDB(Exception ex, string msg, string component_id, string host, string DT)
        {
            byte[] imageByte = createScreenShot(DT);

            TEST_STATUS_TB tb = new TEST_STATUS_TB
            {
                Test_ID = DT,
                ACTION = msg,
                STATUS = STATUS.FAIL.ToString(),
                ERROR_DETAILS = ex.Message,
                COMPONENT_ID = component_id,
                Creation_Time = DateTime.Now,
                HOST = host,
                IMAGE = imageByte
                //  IMAGE = Convert.ToInt32(fs.Length);

            };
            db.TEST_STATUS_TB.Add(tb);
            db.SaveChanges();
            db.Dispose();



        }

        private static byte[] createScreenShot(string DT)
        {
         //   driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + DT + ".png", ImageFormat.Png);
            string filePath = @"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + DT + ".png";

            FileInfo fInfo = new FileInfo(filePath);
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryReader rdr = new BinaryReader(fs);
            long numBytes = fInfo.Length;
            byte[] imageByte = null;
            imageByte = rdr.ReadBytes((int)numBytes);
            return imageByte;
        }

        internal void VINSuccedMessage(Campaign c, string urlAdrr, string dT)
        {
            throw new NotImplementedException();
        }

        //internal void ExceptionMessage(Exception ex, string v, string userName, string urlAdrr, string dT, IWebDriver driver)
        //{
        //    throw new NotImplementedException();
        //}

        public void VINSuccedMessage(Vehicle v , string host,string DT)
        {

            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt",
                              "TEST_ID: " + DT + " ---- " + host + " -------" + "Add New VIN Test " + " Date :" + DateTime.Now.ToString()
                              + "----------------------------------------" +
                               Environment.NewLine + "Message :" + "Vehicle " + v.VIN + " Created Successfully "
                               + Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);

            AddSuccessMsgToDB(v.VIN, host, DT, ACTION.Add_New_Vehicle.ToString());
        }

        public void CampSuccedMessage(Campaign c, string host, string DT)
        {
            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt",
                             "TEST_ID: " + DT + " ---- " + host + " -------" + "Add New Campaign Test " + " Date :" + DateTime.Now.ToString()
                             + "----------------------------------------" +
                              Environment.NewLine + "Message :" + "Campaign " + c.Name + " Created Successfully "
                              + Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);

            AddSuccessMsgToDB(c.Name, host, DT, ACTION.Add_New_Campaign.ToString());
        }

       
        

        public void USERSuccedMessage(USER u,string host)
        {
            string DT = DateTime.Now.ToFileTime().ToString();

            

           

            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt",
                             "TEST_ID: " + DT + " ---- " + host + " -------" + "Add New USER Test " + " Date :" + DateTime.Now.ToString()
                              + "----------------------------------------" +
                               Environment.NewLine + "Message :" + "Vehicle " + u.UserName + " Created Successfully "
                               + Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);

            AddSuccessMsgToDB(u.UserName, host, DT, ACTION.Add_New_USER.ToString());
        }

        public void SoftwareSuccedMessage(Software sw , string host )
        {
            string DT = DateTime.Now.ToFileTime().ToString();
           

            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt",
                             "TEST_ID: " + DT + " ---- " + host + " -------" + "Add New Software Test " + " Date :" + DateTime.Now.ToString()
                             + "----------------------------------------" +
                              Environment.NewLine + "Message :" + "Software " + sw.softwareName + " Created Successfully "
                              + Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            AddSuccessMsgToDB(sw.softwareName, host, DT, ACTION.Add_New_Software.ToString());

        }

        private void AddSuccessMsgToDB(string componentName, string host, string DT , string action)
        {
            try
            {
             TEST_STATUS_TB tb = new TEST_STATUS_TB
            {
                Test_ID = DT,
                ACTION = action,
                STATUS = STATUS.PASS.ToString(),
                COMPONENT_ID = componentName,
                Creation_Time = DateTime.Now,
                HOST = host
            
                
            };
            db.TEST_STATUS_TB.Add(tb);
            db.SaveChanges();
            db.Dispose();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx )
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                ExceptionMessage( raise);



            }
            
        }

        public void ExceptionMessage(object ex)
        {
            ;
        }

        private void ExceptionMessage(Exception ex)
        {
            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt",
                              "Exception ERROR-----"+" Date :" + DateTime.Now.ToString()
                               + "----------------------------------------" +
                             Environment.NewLine + "Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                     "" + Environment.NewLine);
            string New = Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine;
            File.AppendAllText(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Log.txt", New);

        }
    }
}
