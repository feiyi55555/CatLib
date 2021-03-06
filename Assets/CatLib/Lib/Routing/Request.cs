﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using CatLib.API.Routing;
using System;
using System.Collections.Generic;

namespace CatLib.Routing
{

    /// <summary>
    /// 请求
    /// </summary>
    public class Request : IRequest
    {

        /// <summary>
        /// 统一资源标识符
        /// </summary>
        protected Uri uri;

        /// <summary>
        /// 使用的路由
        /// </summary>
        protected Route route;

        /// <summary>
        /// 参数表
        /// </summary>
        protected Dictionary<string, string> parameters = new Dictionary<string, string>();

        /// <summary>
        /// Uri
        /// </summary>
        public System.Uri Uri { get { return uri.Original; } }

        /// <summary>
        /// Uri
        /// </summary>
        public Uri CatLibUri { get { return uri; } }

        /// <summary>
        /// 上下文
        /// </summary>
        protected object context;

        /// <summary>
        /// 构建一个请求
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="context"></param>
        public Request(string uri , object context)
        {
            this.uri = new Uri(uri);
            this.context = context;
        }

        /// <summary>
        /// 构成uri路径段的数组
        /// </summary>
        /// <param name="index">下标</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public string Segment(int index, string defaultValue = null)
        {
            if(index < uri.Segments.Length)
            {
                return uri.Segments[index];
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取上下文
        /// </summary>
        /// <returns></returns>
        public object GetContext()
        {
            return context;
        }

        /// <summary>
        /// 获取字符串附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string Get(string key, string defaultValue = null)
        {
            if(parameters != null)
            {
                if (parameters.ContainsKey(key))
                {
                    return parameters[key];
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取字符串附加物
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key] { get { return Get(key); } }

        /// <summary>
        /// 获取字符串附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetString(string key, string defaultValue = null)
        {
            return Get(key , defaultValue);
        }

        /// <summary>
        /// 获取整型的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int GetInt(string key, int defaultValue = 0)
        {
            return int.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 获取长整型的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public long GetLong(string key, long defaultValue = 0)
        {
            return long.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 获取短整型的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public short GetShort(string key, short defaultValue = 0)
        {
            return short.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 获取字符的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public char GetChar(string key, char defaultValue = char.MinValue)
        {
            return char.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 获取浮点数的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public float GetFloat(string key, float defaultValue = 0)
        {
            return float.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 获取双精度浮点数的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double GetDouble(string key, double defaultValue = 0)
        {
            return double.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 获取布尔值的附加物
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool GetBoolean(string key, bool defaultValue = false)
        {
            return bool.Parse(GetString(key) ?? defaultValue.ToString());
        }

        /// <summary>
        /// 设定参数
        /// </summary>
        /// <param name="parameters"></param>
        public Request SetParameters(Dictionary<string, string> parameters)
        {
            this.parameters = parameters;
            return this;
        }

        /// <summary>
        /// 增加参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public Request AddParameters(string key, string val)
        {

            parameters.Remove(key);
            parameters.Add(key, val);
            return this;

        }

        /// <summary>
        /// 设定路由方案
        /// </summary>
        /// <param name="route">路由方案</param>
        /// <returns></returns>
        public Request SetRoute(Route route)
        {
            this.route = route;
            return this;
        }

    }

}