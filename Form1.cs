using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ローカルMongoDBに接続
            MongoClient cli = new MongoClient("mongodb://localhost/app01");

            // Databaseを選択
            MongoDatabase db = cli.GetServer().GetDatabase("app01");

            // コレクションの取得
            MongoCollection<user> col = db.GetCollection<user>("user");

            // データ作成
            user entry = new user()
            {
                Name = "uozy",
                Birthday = DateTime.Parse("1984/01/01"),
                EmailAddrs = "aaa@uozy.com"

            };
            // データ挿入
            col.Insert(entry);
        }
    }

    [BsonIgnoreExtraElements]
    public class user
    {
        [BsonId]
        public BsonObjectId _id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public String EmailAddrs { get; set; }
    }

}
