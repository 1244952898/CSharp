using Aliyun.OSS;
using Aliyun.OSS.Common;
using System;

namespace CSharp
{
    public class AliyunOSS
    {
        public void Upload()
        {
            //http://oss-cn-huzhou-tongyong-d01-a.ops.core.gee-cloud.com
            // yourEndpoint填写Bucket所在地域对应的Endpoint。以华东1（杭州）为例，Endpoint填写为https://oss-cn-hangzhou.aliyuncs.com。
            var endpoint = "http://oss-cn-huzhou-tongyong-d01-a.ops.core.gee-cloud.com";
            // 从环境变量中获取访问凭证。运行本代码示例之前，请确保已设置环境变量OSS_ACCESS_KEY_ID和OSS_ACCESS_KEY_SECRET。
            var accessKeyId = "xlQ1EC3bCa1isdvi";
            var accessKeySecret = "TTeI05DdgDtBsXCXuNUCruYR0vbb0m";
            // 填写Bucket名称，例如examplebucket。
            var bucketName = "gecp-test";
            // 填写Object完整路径，Object完整路径中不能包含Bucket名称，例如exampledir/exampleobject.txt。
            var objectName = "test/bigfile/1.zip";
            // 填写本地文件的完整路径，例如D:\\localpath\\examplefile.txt。
            // 如果未指定本地路径只填写了文件名称（例如examplefile.txt），则默认从示例程序所属项目对应本地路径中上传文件。
            var localFilename = "D:\\Projects\\1.zip";
            // 记录本地分片上传结果的文件。上传过程中的进度信息会保存在该文件中。
            string checkpointDir = "D:\\Projects\\11.txt";

            // 创建OssClient实例。
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                // 通过UploadFileRequest设置多个参数。
                UploadObjectRequest request = new UploadObjectRequest(bucketName, objectName, localFilename)
                {
                    // 指定上传的分片大小。
                    PartSize = 8 * 1024 * 1024,
                    // 指定并发线程数。
                    ParallelThreadCount = 3,
                    // checkpointDir保存断点续传的中间状态，用于失败后继续上传。
                    // 如果checkpointDir为null，断点续传功能不会生效，每次失败后都会重新上传。
                    CheckpointDir = checkpointDir,
                };
                // 断点续传上传。
                var result = client.ResumableUploadObject(request);
                Console.WriteLine("Resumable upload object:{0} succeeded", objectName);
            }
            catch (OssException ex)
            {
                Console.WriteLine("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed with error info: {0}", ex.Message);
            }
        }

        public void Upload1()
        {
            // yourEndpoint填写Bucket所在地域对应的Endpoint。以华东1（杭州）为例，Endpoint填写为https://oss-cn-hangzhou.aliyuncs.com。
            var endpoint = "http://oss-cn-huzhou-tongyong-d01-a.ops.core.gee-cloud.com";
            // 从环境变量中获取访问凭证。运行本代码示例之前，请确保已设置环境变量OSS_ACCESS_KEY_ID和OSS_ACCESS_KEY_SECRET。
            var accessKeyId = "xlQ1EC3bCa1isdvi";
            var accessKeySecret = "TTeI05DdgDtBsXCXuNUCruYR0vbb0m";
            // 填写Bucket名称，例如examplebucket。
            var bucketName = "gecp-test";
            // 填写Object完整路径，完整路径中不能包含Bucket名称，例如exampledir/exampleobject.txt。
            var objectName = "test/bigfile/1.zip";
            // 填写本地文件的完整路径。如果未指定本地路径，则默认从示例程序所属项目对应本地路径中上传文件。
            var localFilename = "D:\\Projects\\1.zip";

            // 创建OssClient实例。
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                // 上传文件。
                client.PutObject(bucketName, objectName, localFilename);
                Console.WriteLine("Put object succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put object failed, {0}", ex.Message);
            }
        }
    }
}
