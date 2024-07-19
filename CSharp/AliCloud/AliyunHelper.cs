using Aliyun.OSS;
using Aliyun.OSS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Threading;
using System.Web;

namespace CSharp.AliCloud
{
    public class AliyunHelper
    {
        #region Fields

        private AliyunConfig _config;
        private OssClient ossClient = null;

        #endregion

        #region Constructors
        public AliyunHelper()
        {
            _config = new AliyunConfig();
            ossClient = GetOssClient();
        }
        #endregion

        #region Public Methods

        public static AliyunHelper Build()
        {
            return new AliyunHelper();
        }

        /// <summary>
        /// 配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public AliyunHelper Config(Action<AliyunConfig> configAction = null)
        {
            configAction?.Invoke(_config);
            return this;
        }

        /// <summary>
        /// 获取OssClient
        /// </summary>
        /// <returns></returns>
        public OssClient GetOssClient(Action<ClientConfiguration> configAction = null)
        {
            var conf = new ClientConfiguration();
            // 设置最大并发连接数
            ClientConfiguration.ConnectionLimit = _config.ClientConfig.ConnectionLimit;
            // 设置请求失败后最大的重试次数
            conf.MaxErrorRetry = _config.ClientConfig.MaxErrorRetry;
            // 设置连接超时时间(毫秒)
            conf.ConnectionTimeout = _config.ClientConfig.ConnectionTimeout;
            // 开启MD5校验
            conf.EnalbeMD5Check = _config.ClientConfig.EnalbeMD5Check;

            //配置ClientConfiguration
            configAction?.Invoke(conf);

            // 创建OSSClient实例
            ossClient = new OssClient(_config.Url, _config.AccessKeyId, _config.AccessKeySecret, conf);
            return ossClient;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="client"></param>
        /// <param name="objectName">"GECP/PCR2309130008.json"</param>
        /// <param name="localFileName">"D:\\PCR2309130008.json"</param>
        /// <returns></returns>
        public AliyunBase UploadFile(string objectName, string localFileName, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            if (string.IsNullOrWhiteSpace(objectName))
            {
                return Fail("objectName is required");
            }
            if (string.IsNullOrWhiteSpace(localFileName))
            {
                return Fail("localFileName is required");
            }
            if (!File.Exists(localFileName))
            {
                return Fail($"文件不存在{localFileName}");
            }
            try
            {
                PutObjectResult result = client.PutObject(bucketName, objectName, localFileName);
                if (result.HttpStatusCode != HttpStatusCode.OK)
                {
                    return Fail($"上传文件失败{localFileName}");
                }
                ////_log.Info("阿里云上传文件: {0} ", result.ETag);
                return Success(result.ETag);
            }
            catch (Exception ex)
            {
                //_log.Error($"阿里云上传文件失败：{ex.Message}");
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 通过流上传文件
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="localFileName"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public AliyunBase UploadFile(string objectName, Stream stream, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            if (string.IsNullOrWhiteSpace(objectName))
            {
                return Fail("objectName is required");
            }
            if (stream == null)
            {
                return Fail($"文件流不存在");
            }
            try
            {
                PutObjectResult result = client.PutObject(bucketName, objectName, stream);
                if (result.HttpStatusCode != HttpStatusCode.OK)
                {
                    return Fail($"上传文件失败");
                }
                ////_log.Info("阿里云上传文件: {0} ", result.ETag);
                return Success(result.ETag);
            }
            catch (Exception ex)
            {
                //_log.Error($"阿里云上传文件失败：{ex.Message}");
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 上传大文件
        /// </summary>
        /// <param name="client"></param>
        public void UploadLargeFile(string objectName, string localFileName, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            //string objectName = "GECP/JetBrains.dotUltimate.2022.2.3.exe";
            //string localFileName = "D:\\Software\\VS\\JetBrains.dotUltimate.2022.2.3.exe";

            try
            {
                DateTime startTime = DateTime.Now;
                ////_log.Info("阿里云开始上传大文件: " + startTime.ToString("yyyy-MM-dd HH:mm:ss"));

                var result = client.PutObject(bucketName, objectName, localFileName);

                DateTime endTime = DateTime.Now;
                ////_log.Info("阿里云大文件上传成功: " + endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                ////_log.Info("阿里云上传耗时: ", endTime - startTime);

            }
            catch (Exception ex)
            {
                //_log.Error($"阿里云上传大文件失败：{ex.Message}");
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="objectName">"GECP/FO手工处理单据列表.xlsx"</param>
        /// <param name="downloadFileName">"D:\\FO手工处理单据列表.xlsx</param>
        /// <param name="client"></param>
        public void DownloadFile(string objectName, string downloadFileName, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            var result = client.GetObject(bucketName, objectName);
            if (result.HttpStatusCode != HttpStatusCode.OK)
            {
                //_log.Error($"阿里云下载文件失败");
            }
            using (var requestStream = result.Content)
            {
                using (var fs = File.Open(downloadFileName, FileMode.Create))
                {
                    int length = 4 * 1024;
                    var buf = new byte[length];
                    do
                    {
                        length = requestStream.Read(buf, 0, length);
                        fs.Write(buf, 0, length);
                    } while (length != 0);
                }
            }
            ////_log.Info("Get object succeeded");
        }

        /// <summary>
        /// 下载文件获取文件流
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="downloadFileName"></param>
        /// <param name="client"></param>
        public AliyunResultModel<MemoryStream> DownloadFile(string objectName, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;

            try
            {
                var result = client.GetObject(bucketName, objectName);
                if (result.HttpStatusCode != HttpStatusCode.OK)
                {
                    //_log.Error($"阿里云下载文件失败");
                }
                using (var requestStream = result.Content)
                {
                    int length = 4 * 1024;
                    var buf = new byte[length];
                    var ms = new MemoryStream();
                    do
                    {
                        length = requestStream.Read(buf, 0, length);
                        ms.Write(buf, 0, length);
                    }
                    while (length != 0);

                    ms.Position = 0;
                    ////_log.Info("Get object succeeded");
                    return Success("Get object succeeded", ms);
                }
            }
            catch (Exception ex)
            {
                //_log.Error($"阿里云下载文件失败异常：异常信息：{ex.Message}");
                return Fail<MemoryStream>("List objects failed");
            }
        }

        /// <summary>
        /// 分片上传文件
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="localFileName"></param>
        /// <param name="client"></param>
        public void MultipartUploadFile(string objectName, string localFileName, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            string uploadId = InitMultipart(objectName, client);
            if (string.IsNullOrWhiteSpace(uploadId))
            {
                return;
            }

            // 计算分片总数。
            var partSize = 100 * 1024;
            var fi = new FileInfo(localFileName);
            var fileSize = fi.Length;
            var partCount = fileSize / partSize;
            if (fileSize % partSize != 0)
            {
                partCount++;
            }

            // 开始分片上传。PartETags是保存PartETag的列表，OSS收到用户提交的分片列表后，会逐一验证每个分片数据的有效性。当所有的数据分片通过验证后，OSS会将这些分片组合成一个完整的文件。
            var partETags = new List<PartETag>();
            try
            {
                using (var fs = File.Open(localFileName, FileMode.Open))
                {
                    for (var i = 0; i < partCount; i++)
                    {
                        var skipBytes = (long)partSize * i;
                        // 定位到本次上传的起始位置。
                        fs.Seek(skipBytes, 0);
                        // 计算本次上传的分片大小，最后一片为剩余的数据大小。
                        var size = (partSize < fileSize - skipBytes) ? partSize : (fileSize - skipBytes);
                        var request = new UploadPartRequest(bucketName, objectName, uploadId)
                        {
                            InputStream = fs,
                            PartSize = size,
                            PartNumber = i + 1
                        };
                        // 调用UploadPart接口执行上传功能，返回结果中包含了这个数据片的ETag值。
                        var result = client.UploadPart(request);
                        partETags.Add(result.PartETag);
                        Console.WriteLine("finish {0}/{1}", partETags.Count, partCount);
                    }
                    Console.WriteLine("Put multi part upload succeeded");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put multi part upload failed, {0}", ex.Message);
            }
            // 完成分片上传。
            try
            {
                var completeMultipartUploadRequest = new CompleteMultipartUploadRequest(bucketName, objectName, uploadId);
                foreach (var partETag in partETags)
                {
                    completeMultipartUploadRequest.PartETags.Add(partETag);
                }
                var result = client.CompleteMultipartUpload(completeMultipartUploadRequest);
                Console.WriteLine("complete multi part succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("complete multi part failed, {0}", ex.Message);
            }
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <returns></returns>
        public AliyunResultModel<IEnumerable<OssObjectSummary>> GetFileList(Action<ListObjectsRequest> configRequest = null, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            try
            {
                var listObjectsRequest = new ListObjectsRequest(bucketName);
                configRequest?.Invoke(listObjectsRequest);
                // 简单列举Bucket中的文件，默认返回100条记录。
                var result = client.ListObjects(listObjectsRequest);
                return Success("List objects succeeded", result.ObjectSummaries);
            }
            catch (Exception ex)
            {
                Console.WriteLine("List objects failed. {0}", ex.Message);
            }
            return Fail<IEnumerable<OssObjectSummary>>("List objects failed");
        }

        /// <summary>
        /// 拷贝小文件（转移）
        /// </summary>
        /// <param name="sourceObject"></param>
        /// <param name="targetObject"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public AliyunBase MoveFile(string sourceObject, string targetObject, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;

            try
            {
                var metadata = new ObjectMetadata();
                var req = new CopyObjectRequest(bucketName, sourceObject, bucketName, targetObject)
                {
                    // 如果NewObjectMetadata为null则为COPY模式（即拷贝源文件的元信息），非null则为REPLACE模式（覆盖源文件的元信息）。
                    NewObjectMetadata = metadata
                };
                var result = client.CopyObject(req);
                return Success("Copy object succeeded");
            }
            catch (OssException ex)
            {
                return Fail(string.Format("Failed with error code: {0}; Error info: {1}. \nRequestID: {2} \tHostID: {3}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId));
            }
            catch (Exception ex)
            {
                return Fail(string.Format("Failed with error info: {0}", ex.Message));
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public AliyunBase DeleteFile(string objectName, OssClient client = null)
        {
            if (client == null)
            {
                client = ossClient;
            }
            string bucketName = _config.Bucket;
            try
            {
                // 删除文件。
                client.DeleteObject(bucketName, objectName);
                return Success("Delete object succeeded");
            }
            catch (Exception ex)
            {
                return Fail(string.Format("Delete object failed. {0}", ex.Message));
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private AliyunBase Success(string msg)
        {
            return new AliyunBase
            {
                Code = (int)AliyunBaseResultEnum.Success,
                Msg = msg,
            };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private AliyunBase Fail(string msg)
        {
            return new AliyunBase
            {
                Code = (int)AliyunBaseResultEnum.Failed,
                Msg = msg,
            };
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private AliyunResultModel<T> Success<T>(string msg, T t) where T : class
        {
            return new AliyunResultModel<T>
            {
                Code = (int)AliyunBaseResultEnum.Success,
                Msg = msg,
                Data = t
            };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private AliyunResultModel<T> Fail<T>(string msg) where T : class
        {
            return new AliyunResultModel<T>
            {
                Code = (int)AliyunBaseResultEnum.Failed,
                Msg = msg,
            };
        }

        /// <summary>
        /// 初始化分片上传，返回uploadId。
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="client"></param>
        /// <param name="uploadId"></param>
        /// <param name="bucketName"></param>
        private string InitMultipart(string objectName, OssClient client)
        {
            var uploadId = string.Empty;
            try
            {
                // 定义上传的文件及所属Bucket的名称。您可以在InitiateMultipartUploadRequest中设置ObjectMeta，但不必指定其中的ContentLength。
                var request = new InitiateMultipartUploadRequest(_config.Bucket, objectName);
                var result = client.InitiateMultipartUpload(request);
                uploadId = result.UploadId;
                // 打印UploadId。
                Console.WriteLine("Init multi part upload succeeded");
                // 根据uploadId执行取消分片上传事件或者列举已上传分片的操作。
                // 如果您需要根据您需要uploadId执行取消分片上传事件的操作，您需要在调用InitiateMultipartUpload完成初始化分片之后获取uploadId。 
                // 如果您需要根据您需要uploadId执行列举已上传分片的操作，您需要在调用InitiateMultipartUpload完成初始化分片之后，且在调用CompleteMultipartUpload完成分片上传之前获取uploadId。
                Console.WriteLine("Upload Id:{0}", result.UploadId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Init multi part upload failed, {0}", ex.Message);
            }
            return uploadId;
        }
        #endregion
    }
}