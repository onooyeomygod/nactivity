﻿namespace org.activiti.engine.impl.cfg
{
    using org.activiti.engine.impl.interceptor;

    /// <summary>
    /// Command executor that passes commands to the first interceptor in the chain. If no <seealso cref="CommandConfig"/> is passed, the default configuration will be used.
    /// 
    /// 
    /// 
    /// </summary>
    public class CommandExecutorImpl : ICommandExecutor
    {

        protected internal CommandConfig defaultConfig;
        protected internal ICommandInterceptor first;

        /// <summary>
        /// 构造一个命令执行器
        /// </summary>
        /// <param name="defaultConfig"></param>
        /// <param name="first"></param>
        public CommandExecutorImpl(CommandConfig defaultConfig, ICommandInterceptor first)
        {
            this.defaultConfig = defaultConfig;
            this.first = first;
        }

        public virtual ICommandInterceptor First
        {
            get
            {
                return first;
            }
            set
            {
                this.first = value;
            }
        }


        public virtual CommandConfig DefaultConfig
        {
            get
            {
                return defaultConfig;
            }
        }

        /// <summary>
        /// 执行器执行一个命令
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual T execute<T>(ICommand<T> command)
        {
            return execute(defaultConfig, command);
        }


        /// <summary>
        /// 开始拦截器的链式调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual T execute<T>(CommandConfig config, ICommand<T> command)
        {
            return first.execute(config, command);
        }

    }

}