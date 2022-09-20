using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retrieve.Tool
{
    public delegate void SetUISomeInfo();
    public partial class LoaderForm : Loading
    {
        public LoaderForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭命令
        /// </summary>
        public void closeOrder()
        {
            if (this.InvokeRequired)
            {
                //这里利用委托进行窗体的操作，避免跨线程调用时抛异常，后面给出具体定义
                SetUISomeInfo UIinfo = new SetUISomeInfo(new Action(() =>
                {
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    if (this.IsDisposed)
                        return;
                    if (!this.IsDisposed)
                    {
                        this.Dispose();
                    }

                }));
                this.Invoke(UIinfo);
            }
            else
            {
                if (this.IsDisposed)
                    return;
                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }

        private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.IsDisposed)
            {
                this.Dispose(true);
            }

        }

    }
    class LoadingHelper
    {
        #region 相关变量定义
        /// <summary>
        /// 定义委托进行窗口关闭
        /// </summary>
        private delegate void CloseDelegate();
        private static LoaderForm loadingForm;
        private static readonly Object syncLock = new Object();  //加锁使用

        #endregion

        private LoadingHelper()
        {

        }

        /// <summary>
        /// 显示loading框
        /// </summary>
        public static void ShowLoadingScreen()
        {
            // Make sure it is only launched once.
            if (loadingForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(LoadingHelper.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        private static void ShowForm()
        {
            if (loadingForm != null)
            {
                loadingForm.closeOrder();
                loadingForm = null;
            }
            loadingForm = new LoaderForm();
            loadingForm.TopMost = true;
            loadingForm.ShowDialog();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public static void CloseForm()
        {
            Thread.Sleep(50); //可能到这里线程还未起来，所以进行延时，可以确保线程起来，彻底关闭窗口
            if (loadingForm != null)
            {
                lock (syncLock)
                {
                    Thread.Sleep(50);
                    if (loadingForm != null)
                    {
                        Thread.Sleep(50);  //通过三次延时，确保可以彻底关闭窗口
                        loadingForm.Invoke(new CloseDelegate(LoadingHelper.CloseFormInternal));
                    }
                }
            }
        }

        /// <summary>
        /// 关闭窗口，委托中使用
        /// </summary>
        private static void CloseFormInternal()
        {

            loadingForm.closeOrder();
            loadingForm = null;

        }

    }
}
