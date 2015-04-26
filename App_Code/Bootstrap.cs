using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bootstrap
/// </summary>
public class Bootstrap
{
    public static string Alert(string content, int type)
    {
        switch (type)
        {
            case 1:
                content = "<div class='alert alert-success'>" + content + "</div>";
                return content;
            case 2:
                content = "<div class='alert alert-info'>" + content + "</div>";
                return content;
            case 3:
                content = "<div class='alert alert-warning'>" + content + "</div>";
                return content;
            case 4:
                content = "<div class='alert alert-danger'>" + content + "</div>";
                return content;
        }
        return content;
    }

    public static string Active(string active)
    {
        if (Convert.ToBoolean(active))
            return "list-group-item-text";
        return "active";
    }

    public static string Badge(string badgeContent, string showBool)
    {
        var show = Convert.ToBoolean(showBool);
        return show == false ? "<span class='badge'>" + badgeContent + "</span>" : "";
    }

    public static string SetFocus(string dataId, string queryId)
    {
        return dataId == queryId ? "disabled" : "";
    }

    public static string Image(string imagePath, int height, int width, string mode, bool backend)
    {
        var filepath = backend ? "../upload/" : "/upload/";
        return "<img class='img-responsive img-border' src='" + filepath + imagePath + ".ashx?width=" + width + "&height=" + height + "&mode=" + mode + "' />";
    }

    public static string MediaObject(string imagePath, int height, int width, string mode, bool backend)
    {
        var filepath = backend ? "../upload/" : "/upload/";
        return "<img class='media-object' src='" + filepath + imagePath + ".ashx?width=" + width + "&height=" + height + "&mode=" + mode + "' />";
    }

    public static string ShortenContent(string texToShorten, int value)
    {
        return (texToShorten.Length >= value
            ? texToShorten.Substring(0, value)
            : texToShorten.Substring(0, texToShorten.Length));
    }
}