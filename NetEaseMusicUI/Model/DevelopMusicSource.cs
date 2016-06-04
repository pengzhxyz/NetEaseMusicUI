using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEaseMusicUI.Model
{

   

    public class DevelopMusicSource
    {

        public int code { get; set; }
        public ApiPersonalizedTaste apipersonalizedtaste { get; set; }
        public ApiV2BannerGet apiv2bannerget { get; set; }
        public ApiPersonalizedPlaylist apipersonalizedplaylist { get; set; }
        public ApiPersonalizedNewsong apipersonalizednewsong { get; set; }
        public ApiPersonalizedMv apipersonalizedmv { get; set; }
        public ApiPersonalizedDjprogram apipersonalizeddjprogram { get; set; }
        public ApiPersonalizedPrivatecontent apipersonalizedprivatecontent { get; set; }
    }

    public class ApiPersonalizedTaste
    {
        public int code { get; set; }
        public bool haveRcmd { get; set; }
    }

    public class ApiV2BannerGet
    {
        public Banner[] banners { get; set; }
        public int code { get; set; }
    }

    public class Banner
    {
        public bool exclusive { get; set; }
        public int targetType { get; set; }
        public string pic { get; set; }
        public string titleColor { get; set; }
        public string typeTitle { get; set; }
        public string url { get; set; }
        public int targetId { get; set; }
        public Song song { get; set; }
        public Program program { get; set; }
    }

    public class Song
    {
        public object[] rtUrls { get; set; }
        public Ar[] ar { get; set; }
        public Al al { get; set; }
        public int st { get; set; }
        public int no { get; set; }
        public string cd { get; set; }
        public object rtUrl { get; set; }
        public object crbt { get; set; }
        public object a { get; set; }
        public M m { get; set; }
        public int pop { get; set; }
        public object rt { get; set; }
        public int mst { get; set; }
        public int cp { get; set; }
        public int mv { get; set; }
        public string cf { get; set; }
        public int dt { get; set; }
        public H h { get; set; }
        public L l { get; set; }
        public int pst { get; set; }
        public string[] alia { get; set; }
        public int fee { get; set; }
        public int ftype { get; set; }
        public int rtype { get; set; }
        public object rurl { get; set; }
        public int t { get; set; }
        public int v { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Privilege privilege { get; set; }
    }

    public class Al
    {
        public int id { get; set; }
        public string name { get; set; }
        public string pic_str { get; set; }
        public long pic { get; set; }
        public string[] alia { get; set; }
    }

    public class M
    {
        public int br { get; set; }
        public long fid { get; set; }
        public int size { get; set; }
        public float vd { get; set; }
    }

    public class H
    {
        public int br { get; set; }
        public long fid { get; set; }
        public int size { get; set; }
        public float vd { get; set; }
    }

    public class L
    {
        public int br { get; set; }
        public long fid { get; set; }
        public int size { get; set; }
        public float vd { get; set; }
    }

    public class Privilege
    {
        public int id { get; set; }
        public int fee { get; set; }
        public int payed { get; set; }
        public int st { get; set; }
        public int pl { get; set; }
        public int dl { get; set; }
        public int sp { get; set; }
        public int cp { get; set; }
        public int subp { get; set; }
        public bool cs { get; set; }
        public int maxbr { get; set; }
        public int fl { get; set; }
    }

    public class Ar
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Program
    {
        public Mainsong mainSong { get; set; }
        public object songs { get; set; }
        public Dj dj { get; set; }
        public string blurCoverUrl { get; set; }
        public Radio radio { get; set; }
        public int mainTrackId { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public object titbitImages { get; set; }
        public bool isPublish { get; set; }
        public long createTime { get; set; }
        public string coverUrl { get; set; }
        public string commentThreadId { get; set; }
        public object[] channels { get; set; }
        public object titbits { get; set; }
        public int bdAuditStatus { get; set; }
        public int pubStatus { get; set; }
        public int serialNum { get; set; }
        public int listenerCount { get; set; }
        public int subscribedCount { get; set; }
        public int trackCount { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public bool subscribed { get; set; }
    }

    public class Mainsong
    {
        public bool starred { get; set; }
        public int popularity { get; set; }
        public int starredNum { get; set; }
        public int playedNum { get; set; }
        public int dayPlays { get; set; }
        public int hearTime { get; set; }
        public string mp3Url { get; set; }
        public object rtUrls { get; set; }
        public int status { get; set; }
        public string disc { get; set; }
        public int no { get; set; }
        public object audition { get; set; }
        public object ringtone { get; set; }
        public object rtUrl { get; set; }
        public object[] alias { get; set; }
        public object crbt { get; set; }
        public int position { get; set; }
        public int duration { get; set; }
        public Hmusic hMusic { get; set; }
        public Mmusic mMusic { get; set; }
        public Lmusic lMusic { get; set; }
        public int score { get; set; }
        public int copyrightId { get; set; }
        public Artist2[] artists { get; set; }
        public Album album { get; set; }
        public string commentThreadId { get; set; }
        public int fee { get; set; }
        public int mvid { get; set; }
        public int ftype { get; set; }
        public int rtype { get; set; }
        public object rurl { get; set; }
        public string copyFrom { get; set; }
        public Bmusic bMusic { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Privilege1 privilege { get; set; }
    }

    public class Hmusic
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Mmusic
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Lmusic
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Album
    {
        public object[] songs { get; set; }
        public int status { get; set; }
        public string tags { get; set; }
        public object[] alias { get; set; }
        public string description { get; set; }
        public int copyrightId { get; set; }
        public Artist1[] artists { get; set; }
        public string blurPicUrl { get; set; }
        public int companyId { get; set; }
        public long pic { get; set; }
        public long picId { get; set; }
        public string briefDesc { get; set; }
        public Artist artist { get; set; }
        public string picUrl { get; set; }
        public string commentThreadId { get; set; }
        public int publishTime { get; set; }
        public object company { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public object type { get; set; }
        public int size { get; set; }
    }

    public class Artist
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Artist1
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Bmusic
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Privilege1
    {
        public int id { get; set; }
        public int fee { get; set; }
        public int payed { get; set; }
        public int st { get; set; }
        public int pl { get; set; }
        public int dl { get; set; }
        public int sp { get; set; }
        public int cp { get; set; }
        public int subp { get; set; }
        public bool cs { get; set; }
        public int maxbr { get; set; }
        public int fl { get; set; }
    }

    public class Artist2
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Dj
    {
        public string backgroundUrl { get; set; }
        public bool followed { get; set; }
        public int djStatus { get; set; }
        public string description { get; set; }
        public string nickname { get; set; }
        public int userId { get; set; }
        public string avatarUrl { get; set; }
        public bool mutual { get; set; }
        public int vipType { get; set; }
        public object expertTags { get; set; }
        public long avatarImgId { get; set; }
        public long backgroundImgId { get; set; }
        public int province { get; set; }
        public int city { get; set; }
        public long birthday { get; set; }
        public int gender { get; set; }
        public int accountStatus { get; set; }
        public int userType { get; set; }
        public int authStatus { get; set; }
        public bool defaultAvatar { get; set; }
        public string detailDescription { get; set; }
        public string signature { get; set; }
        public int authority { get; set; }
        public string brand { get; set; }
    }

    public class Radio
    {
        public object dj { get; set; }
        public string category { get; set; }
        public string desc { get; set; }
        public long createTime { get; set; }
        public string picUrl { get; set; }
        public int categoryId { get; set; }
        public int programCount { get; set; }
        public int subCount { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ApiPersonalizedPlaylist
    {
        public bool hasTaste { get; set; }
        public int code { get; set; }
        public int category { get; set; }
        public Result[] result { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string copywriter { get; set; }
        public string picUrl { get; set; }
        public bool canDislike { get; set; }
        public float playCount { get; set; }
        public int trackCount { get; set; }
        public bool highQuality { get; set; }
        public string alg { get; set; }
    }

    public class ApiPersonalizedNewsong
    {
        public int code { get; set; }
        public int category { get; set; }
        public Result1[] result { get; set; }
    }

    public class Result1
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public object copywriter { get; set; }
        public object picUrl { get; set; }
        public bool canDislike { get; set; }
        public Song1 song { get; set; }
        public string alg { get; set; }
    }

    public class Song1
    {
        public bool starred { get; set; }
        public int popularity { get; set; }
        public int starredNum { get; set; }
        public int playedNum { get; set; }
        public int dayPlays { get; set; }
        public int hearTime { get; set; }
        public string mp3Url { get; set; }
        public object rtUrls { get; set; }
        public int status { get; set; }
        public string disc { get; set; }
        public int no { get; set; }
        public object audition { get; set; }
        public string ringtone { get; set; }
        public object rtUrl { get; set; }
        public string[] alias { get; set; }
        public object crbt { get; set; }
        public int position { get; set; }
        public int duration { get; set; }
        public Hmusic1 hMusic { get; set; }
        public Mmusic1 mMusic { get; set; }
        public Lmusic1 lMusic { get; set; }
        public int score { get; set; }
        public int copyrightId { get; set; }
        public Artist5[] artists { get; set; }
        public Album1 album { get; set; }
        public string commentThreadId { get; set; }
        public int fee { get; set; }
        public int mvid { get; set; }
        public int ftype { get; set; }
        public int rtype { get; set; }
        public object rurl { get; set; }
        public string copyFrom { get; set; }
        public Bmusic1 bMusic { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public Privilege2 privilege { get; set; }
        public string[] transNames { get; set; }
    }

    public class Hmusic1
    {
        public int sr { get; set; }
        public float volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Mmusic1
    {
        public int sr { get; set; }
        public float volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Lmusic1
    {
        public int sr { get; set; }
        public float volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Album1
    {
        public object[] songs { get; set; }
        public int status { get; set; }
        public string tags { get; set; }
        public string[] alias { get; set; }
        public string description { get; set; }
        public int copyrightId { get; set; }
        public Artist4[] artists { get; set; }
        public string blurPicUrl { get; set; }
        public int companyId { get; set; }
        public long pic { get; set; }
        public long picId { get; set; }
        public string briefDesc { get; set; }
        public Artist3 artist { get; set; }
        public string picUrl { get; set; }
        public string commentThreadId { get; set; }
        public long publishTime { get; set; }
        public string company { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string picId_str { get; set; }
    }

    public class Artist3
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Artist4
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Bmusic1
    {
        public int sr { get; set; }
        public float volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Privilege2
    {
        public int id { get; set; }
        public int fee { get; set; }
        public int payed { get; set; }
        public int st { get; set; }
        public int pl { get; set; }
        public int dl { get; set; }
        public int sp { get; set; }
        public int cp { get; set; }
        public int subp { get; set; }
        public bool cs { get; set; }
        public int maxbr { get; set; }
        public int fl { get; set; }
    }

    public class Artist5
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class ApiPersonalizedMv
    {
        public int code { get; set; }
        public int category { get; set; }
        public Result2[] result { get; set; }
    }

    public class Result2
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string copywriter { get; set; }
        public string picUrl { get; set; }
        public bool canDislike { get; set; }
        public int duration { get; set; }
        public int playCount { get; set; }
        public bool subed { get; set; }
        public Artist6[] artists { get; set; }
        public string artistName { get; set; }
        public int artistId { get; set; }
        public string alg { get; set; }
    }

    public class Artist6
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ApiPersonalizedDjprogram
    {
        public int code { get; set; }
        public int category { get; set; }
        public Result3[] result { get; set; }
    }

    public class Result3
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string copywriter { get; set; }
        public string picUrl { get; set; }
        public bool canDislike { get; set; }
        public Program1 program { get; set; }
        public string alg { get; set; }
    }

    public class Program1
    {
        public Mainsong1 mainSong { get; set; }
        public object songs { get; set; }
        public Dj1 dj { get; set; }
        public string blurCoverUrl { get; set; }
        public Radio1 radio { get; set; }
        public int mainTrackId { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public object titbitImages { get; set; }
        public bool isPublish { get; set; }
        public long createTime { get; set; }
        public string coverUrl { get; set; }
        public string commentThreadId { get; set; }
        public string[] channels { get; set; }
        public object titbits { get; set; }
        public int bdAuditStatus { get; set; }
        public int pubStatus { get; set; }
        public int serialNum { get; set; }
        public int listenerCount { get; set; }
        public int subscribedCount { get; set; }
        public int trackCount { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Mainsong1
    {
        public bool starred { get; set; }
        public int popularity { get; set; }
        public int starredNum { get; set; }
        public int playedNum { get; set; }
        public int dayPlays { get; set; }
        public int hearTime { get; set; }
        public string mp3Url { get; set; }
        public object rtUrls { get; set; }
        public int status { get; set; }
        public string disc { get; set; }
        public int no { get; set; }
        public object audition { get; set; }
        public object ringtone { get; set; }
        public object rtUrl { get; set; }
        public object[] alias { get; set; }
        public object crbt { get; set; }
        public int position { get; set; }
        public int duration { get; set; }
        public Hmusic2 hMusic { get; set; }
        public Mmusic2 mMusic { get; set; }
        public Lmusic2 lMusic { get; set; }
        public int score { get; set; }
        public int copyrightId { get; set; }
        public Artist9[] artists { get; set; }
        public Album2 album { get; set; }
        public string commentThreadId { get; set; }
        public int fee { get; set; }
        public int mvid { get; set; }
        public int ftype { get; set; }
        public int rtype { get; set; }
        public object rurl { get; set; }
        public string copyFrom { get; set; }
        public Bmusic2 bMusic { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Hmusic2
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Mmusic2
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Lmusic2
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Album2
    {
        public object[] songs { get; set; }
        public int status { get; set; }
        public string tags { get; set; }
        public object[] alias { get; set; }
        public string description { get; set; }
        public int copyrightId { get; set; }
        public Artist8[] artists { get; set; }
        public string blurPicUrl { get; set; }
        public int companyId { get; set; }
        public long pic { get; set; }
        public long picId { get; set; }
        public string briefDesc { get; set; }
        public Artist7 artist { get; set; }
        public string picUrl { get; set; }
        public string commentThreadId { get; set; }
        public int publishTime { get; set; }
        public object company { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public object type { get; set; }
        public int size { get; set; }
    }

    public class Artist7
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Artist8
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Bmusic2
    {
        public int sr { get; set; }
        public int volumeDelta { get; set; }
        public int bitrate { get; set; }
        public long dfsId { get; set; }
        public int playTime { get; set; }
        public object name { get; set; }
        public int id { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
    }

    public class Artist9
    {
        public int img1v1Id { get; set; }
        public int musicSize { get; set; }
        public object[] alias { get; set; }
        public int picId { get; set; }
        public string briefDesc { get; set; }
        public string picUrl { get; set; }
        public int albumSize { get; set; }
        public string img1v1Url { get; set; }
        public string trans { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Dj1
    {
        public string backgroundUrl { get; set; }
        public bool followed { get; set; }
        public int djStatus { get; set; }
        public string description { get; set; }
        public string nickname { get; set; }
        public int userId { get; set; }
        public string avatarUrl { get; set; }
        public bool mutual { get; set; }
        public int vipType { get; set; }
        public object expertTags { get; set; }
        public long avatarImgId { get; set; }
        public long backgroundImgId { get; set; }
        public int province { get; set; }
        public int city { get; set; }
        public long birthday { get; set; }
        public int gender { get; set; }
        public int accountStatus { get; set; }
        public int userType { get; set; }
        public int authStatus { get; set; }
        public bool defaultAvatar { get; set; }
        public string detailDescription { get; set; }
        public string signature { get; set; }
        public int authority { get; set; }
        public string brand { get; set; }
    }

    public class Radio1
    {
        public object dj { get; set; }
        public string category { get; set; }
        public string desc { get; set; }
        public long createTime { get; set; }
        public string picUrl { get; set; }
        public int categoryId { get; set; }
        public int programCount { get; set; }
        public int subCount { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public bool subed { get; set; }
    }

    public class ApiPersonalizedPrivatecontent
    {
        public int code { get; set; }
        public string name { get; set; }
        public Result4[] result { get; set; }
    }

    public class Result4
    {
        public int id { get; set; }
        public string url { get; set; }
        public string picUrl { get; set; }
        public string sPicUrl { get; set; }
        public int type { get; set; }
        public string copywriter { get; set; }
        public string name { get; set; }
        public string alg { get; set; }
    }
}
