using KikShowAPI.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Models
{
    public class UserPost //: IFromDataReader<UserPost>
    {
        private string _postMotion;
        private string _postImage;
        private string _userAvatar;

        public int Id { get; set; }
        public string PostTitle { get; set; }        
        public string PostMotion 
        {
            get { return Config.BlobUrl + _postMotion; }
            set { _postMotion = value; }
        }
        public string PostImage
        {
            get { return Config.BlobUrl + _postImage; }
            set { _postImage = value; }
        }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAvatar
        {
            get { return Config.BlobUrl + _userAvatar; }
            set { _userAvatar = value; }
        }

        public UserPost()
        {

        }

        public async Task<List<UserPost>> SelectUserPostsAsync()
        {
            await Task.Delay(1);
            BaseDAL baseDAL = new BaseDAL();
            List<UserPost> userPosts = new List<UserPost>();
            DataTable dt = baseDAL.GetDataTable("SelectUserPosts", null);            
            foreach(DataRow dr in dt.Rows)
            {
                UserPost post = new UserPost();
                post.Id = Convert.ToInt32(dr["PostId"]);
                post.PostTitle = dr["PostTitle"] is DBNull ? null : dr["PostTitle"].ToString();
                post.PostMotion = dr["PostMotion"] is DBNull ? null : dr["PostMotion"].ToString();
                post.PostImage = dr["PostImage"] is DBNull ? null : dr["PostImage"].ToString();
                post.PostDate = dr["PostDate"] is DBNull ? new DateTime() : Convert.ToDateTime(dr["PostDate"]);
                post.UserId = dr["UserId"] is DBNull ? 0 : Convert.ToInt32(dr["UserId"]);
                post.UserName = dr["UserName"] is DBNull ? null : dr["UserName"].ToString();
                post.UserAvatar = dr["UserAvatar"] is DBNull ? null : dr["UserAvatar"].ToString();
                userPosts.Add(post);
            }
            return userPosts;
        }

        public async Task InsertUserPostAsync(UserPostData userPD)
        {
            await Task.Delay(1);
            BaseDAL baseDAL = new BaseDAL();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@USERID", userPD.UserId));
            parameters.Add(new SqlParameter("@TITLE", userPD.Title));
            parameters.Add(new SqlParameter("@MOTION", userPD.Motion.FileName));
            parameters.Add(new SqlParameter("@IMAGE", userPD.Image.FileName));
            await baseDAL.ExecuteQueryAsync("InsertUserPost", parameters);
        }
    }
}
