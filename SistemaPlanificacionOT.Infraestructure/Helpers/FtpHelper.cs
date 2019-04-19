using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using SistemaPlanificacionOT.Infraestructure.Settings;
using SistemaPlanificacionOT.Infraestructure.Exceptions;


namespace SistemaPlanificacionOT.Infraestructure.Helpers
{
    public class FtpHelper
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

        public FtpHelper()
        {
            host = ApplicationKeys.FtpServer;
            user = ApplicationKeys.FtpUser;
            pass = ApplicationKeys.FtpPassword;
        }

        public Stream FtpDowloadImgStream(string remoteFile)
        {
            MemoryStream img = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                ftpStream = ftpResponse.GetResponseStream();

                img = new MemoryStream();
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                try
                {
                    while (bytesRead > 0)
                    {
                        img.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bytesRead);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "Error leyendo imagen del servidor");
                    throw new InvalidDataBaseOperationException("Error leyendo imagen del servidor" + ex.Message);
                }
                
                //img.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (System.Net.WebException wex)
            {
                var webResponse = wex.Response as FtpWebResponse;
                if (webResponse.StatusCode.Equals(FtpStatusCode.ActionNotTakenFileUnavailable))
                {
                    return Stream.Null;
                }
                else
                {
                    Logger.LogException(wex, "Error en configuracion Ftp");
                    throw new InvalidDataBaseOperationException("Error en configuracion Ftp" + wex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, "Error en configuracion Ftp");
                throw new InvalidDataBaseOperationException("Error en configuracion Ftp" + ex.Message);
            }
            return img;
        }

        //public string FtpDowloadImgBase64(string remoteFile)
        //{
        //    string base64String = string.Empty;
        //    var img = FtpDowloadImgStream(remoteFile);

        //    byte[] imageBytes = img.ToArray();
        //    base64String = Convert.ToBase64String(imageBytes);
        //    imageBytes = null;

        //    img.Close();
        //}

        public string FtpDowloadImgBase64(string remoteFile)
        {
            MemoryStream img = null;
            string base64String = string.Empty;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                ftpStream = ftpResponse.GetResponseStream();

                img = new MemoryStream();
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                try
                {
                    while (bytesRead > 0)
                    {
                        img.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bytesRead);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "Error leyendo imagen del servidor");
                    throw new InvalidDataBaseOperationException("Error leyendo imagen del servidor" + ex.Message);
                }

                byte[] imageBytes = img.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
                imageBytes = null;

                img.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (System.Net.WebException wex)
            {
                var webResponse = wex.Response as FtpWebResponse;                
                if (webResponse.StatusCode.Equals(FtpStatusCode.ActionNotTakenFileUnavailable))
                {
                    return string.Empty;
                }
                else
                {
                    Logger.LogException(wex, "Error en configuracion Ftp");
                    throw new InvalidDataBaseOperationException("Error en configuracion Ftp" + wex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, "Error en configuracion Ftp");
                throw new InvalidDataBaseOperationException("Error en configuracion Ftp" + ex.Message);
            }
            return base64String;
        }
    }
}
