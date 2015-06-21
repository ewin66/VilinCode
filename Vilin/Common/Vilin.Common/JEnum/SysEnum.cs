using JF.Common.Libary.JAtrribute;

namespace JF.Common.Libary.JEnum
{
    public class SysEnum
    {
        public enum SmsSenderType
        {
            [Name("移动")]
            MOB = 1,

            [Name("联通")]
            UMS = 2,

            [Name("短信猫")]
            SMSCAT = 3,

            [Name("电信")]
            TEL = 4
        }
        public enum PRICE_RANGE
        {
            [Name("500以下")]
            WUBAIYIXIA=0,

            [Name("500-899")]
            WUBAIJIUBAI = 1,

            [Name("900-1099")]
            JIUBAIQIANYI = 2,

            [Name("1100-1299")]
            QIANYIQIANSAN = 3,

            [Name("1300-1999")]
            QIANSANLIANGQIAN = 4,
            [Name("2000-2499")]
            LIANGQIANLIANGQIANWU = 5,

            [Name("2500-3000")]
            LIANGQIANWUSANQIAN = 6,

            [Name("3000以上")]
            SANQIANYISHANG = 7,
        }
        public enum SENSITIVE_ADDRESS
        {
            [Name("军队")]
            ARMY = 0,

            [Name("部队")]
            TROOPS = 1,

            [Name("政府")]
            GOVERNMENT= 2,

            [Name("医院")]
           HOSPITAL = 3,

            [Name("法院")]
            COURTHOSE = 4,

            [Name("公安局")]
            SECURITY  = 5,

            [Name("派出所")]
            STATIONHOUSE = 6,
        }
        public enum SmsType
        {
            [Name("普通短信")]
            NORMAL = 0,

            [Name("定时短信")]
            LOCKED = 1,

            [Name("促销短信")]
            PROMOT = 2
        }

        public enum SmsStatus
        {
            [Name("未发送")]
            UnSent = 0,

            [Name("处理中")]
            Processing = 1,

            [Name("发送成功")]
            SendSuccessful = 2,

            [Name("发送失败")]
            SendFailed = 3,

            [Name("已取消")]
            Canceled = 4,

            [Name("已回复")]
            Replied = 5,

            [Name("队列中")]
            InQueue = 6
        }

        /// <summary>
        /// the smsc return value
        /// </summary>

        public enum SMSC_API_RETURN_VALUE
        {
            [Name("初始化成功")]
            IMAPI_SUCC = 0,

            [Name("连接数据库出错")]
            IMAPI_CONN_ERR = -1,

            [Name("数据库关闭失败")]
            IMAPI_CONN_CLOSE_ERR = -2,

            [Name("数据库插入错误")]
            IMAPI_INS_ERR = -3,

            [Name("数据库删除错误")]
            IMAPI_DEL_ERR = -4,

            [Name("数据库查询错误")]
            IMAPI_QUERY_ERR = -5,

            [Name("参数错误")]
            IMAPI_DATA_ERR = -6,

            [Name("API编码非法")]
            IMAPI_API_ERR = -7,

            [Name("消息内容太长")]
            IMAPI_DATA_TOOLONG = -8,

            [Name("没有初始化或初始化失败")]
            IMAPI_INIT_ERR = -9,

            [Name("API接口处于暂(失效)状态")]
            IMAPI_IFSTATUS_INVALID = -10,

            [Name("短信网关未连接")]
            IMAPI_GATEWAY_CONN_ERR = -11
        }

        public enum USMSC_API_RETURN_VALUE
        {
            [Name("发送短信成功")]
            SEND_SUCC = 0,

            [Name("提交参数不能为空")]
            PARAM_IS_NULL = 1,

            [Name("账号无效或未开户")]
            ACCOUNT_INVALID = 2,

            [Name("账号密码错误")]
            ACCOUNT_PWD_INVALID = 3,

            [Name("预约发送时间无效")]
            SCHEDULE_TIME_INVALID = 4,

            [Name("IP不合法")]
            IP_INVALID = 5,

            [Name("号码中含有无效号码或不在规定的号段")]
            NUMBER_INVALID = 6,

            [Name("内容中含有非法关键字")]
            CONTENT_INVALID = 7,

            [Name("内容长度超过上限，最大402字符")]
            CONTENT_MAX_LIMIT = 8,

            [Name("接受号码过多，最大1000")]
            NUMBER_MAX_LIMIT = 9,

            [Name("黑名单用户")]
            BLACK_LIST_LIMIT = 10,

            [Name("提交速度太快")]
            COMIT_TOO_FAST = 11,

            [Name("您尚未订购[普通短信业务]，暂不能发送该类信息")]
            UN_PUCHARSE_BUSINESS = 12,

            [Name("您的[普通短信业务]剩余数量发送不足，暂不能发送该类信息")]
            SMS_BALANCE_NOT_ENOUGH = 13,

            [Name("流水号格式不正确")]
            SN_INVALID = 14,

            [Name("流水号重复")]
            SN_CONFLICT = 15,

            [Name("超出发送上限（操作员帐户当日发送上限）")]
            SEND_TIMES_MAX_LIMIT = 16,

            [Name("余额不足")]
            BALANCE_NOT_ENOUGH = 17,

            [Name("扣费不成功")]
            CHARGE_UN_SUCSS = 18,

            [Name("系统错误")]
            SYSTEM_ERROR = 20,

            [Name("您只能发送联通的手机号码，本次发送的手机号码中包含了非联通的手机号码")]
            UPHONE_LIMIT = 21,

            [Name("您只能发送移动的手机号码，本次发送的手机号码中包含了非移动的手机号码")]
            MPHONE_LIMIT = 22,

            [Name("您只能发送电信的手机号码，本次发送的手机号码中包含了非电信的手机号码")]
            TPHONE_INVALID = 23,

            [Name("账户状态不正常")]
            ACCOUNT_STATUS_EXCEPTION = 24,

            [Name("账户权限不足")]
            PERMISSION_INVALID = 25,

            [Name("需要人工审核")]
            NEED_APPROVAL = 26,

            [Name("发送内容与模板不符")]
            TEMPLATE_CONTENT_CONFLICT = 28
        }

        public enum USMS_RETURN_VALUE
        {
            [Name("成功")]
            INIT_SUCC = 0,

            [Name("提交参数不能为空")]
            COMMIT_PARAM_NULL = 1,

            [Name("账号无效")]
            ACCOUNT_INVALID = 2,

            [Name("账号密码错误")]
            PWD_ERROR = 3,

            [Name("时间格式不正确,格式为：yyyy-MM-dd HH:mm:ss")]
            TIME_FORMAT_ERROR = 4,

            [Name("系统错误")]
            SYS_ERROR = 20
        }

        public enum USMS_RPT_VALUE
        {
            [Name("成功")]
            SEND_SUCCESS = 0,

            [Name("发送失败")]
            SEND_FAILED = 1
        }

        /// <summary>
        /// the smsc return value
        /// </summary>
        public enum SMS_INIT_VALUE
        {
            [Name("成功")]
            INIT_SUCC = 0,

            [Name("连接失败")]
            CONNECT_FAILED = 1,

            [Name("用户名或密码错误")]
            UID_OR_PWD_ERROR = 2,

            [Name("密码错误")]
            PWD_ERROR = 3,

            [Name("接口编码不存在")]
            INTERFACE_CODE_DONT_EXIST = 4
        }

        /// <summary>
        /// the smsc return value
        /// </summary>
        public enum SMS_SENT_CATEGORYID
        {
            [Name("普通短信")]
            NORMAL_SMS = 0,

            [Name("WAP PUSH短信")]
            WAP_PUSH_SMS = 1,

            [Name("PDU短信")]
            PDU_SMS = 2
        }

        public enum SMS_SUBJECT
        {
            [Name("发送短信")]
            SEND_SMS = 0,

            [Name("接收短信")]
            RECV_SMS = 1,

            [Name("接收回执")]
            RECV_RPT = 2
        }

        //public enum CUSTOMER_GRADE
        //{
        //    [Name("A类")]
        //    GRADE_A = 2,

        //    [Name("无级")]
        //    NO_GRADE = 3,

        //    [Name("B类")]
        //    GRADE_B = 4,

        //    [Name("C类")]
        //    GRADE_C = 5,

        //    [Name("D类")]
        //    GRADE_D = 6,

        //    [Name("无分等级")]
        //    GRADE_ZERO = 7,

        //    [Name("调查单")]
        //    SURVEY_ORDER = 10,

        //    [Name("未知")]
        //    UNKNOW = 11,

        //    [Name("新单")]
        //    NEW_ORDER = 12,

        //    [Name("新单未成交")]
        //    NEW_ORDER_UNFILLED = 13,

        //    [Name("单放弃单")]
        //    DISCARD_ORDER = 19,

        //    [Name("新单已成交")]
        //    NEW_ORDER_TRANSACTION = 25,

        //    [Name("一线已成交")]
        //    FRONT_LINE_TRANSACTION = 29,

        //    [Name("一线未成交")]
        //    FRONT_LINE_UNFILLED = 30,

        //    [Name("维护单")]
        //    MAINTAIN_ORDER = 31,

        //    [Name("增值客户")]
        //    APPRECIATION_CUSTOMER = 32,

        //    [Name("黄金客")]
        //    GLODEN_CUSTOMER = 33,
        //}

        public enum SYS_MODULE
        {
            [Name("客户管理")]
            CUSTOMER_MANAGER = 1,

            [Name("订单管理")]
            ORDER_MANAGER = 2,

            [Name("系统管理")]
            SYSTEM_MANAGER = 4,

            [Name("仓库管理")]
            WAREHOUSE_MANAGER = 5,

            [Name("基础数据")]
            BASEINFO_MANAGER = 6,

            [Name("电话管理")]
            CDR_MANAGER = 7,

            [Name("财务管理")]
            FINANCE_MANAGER = 8,

            [Name("系统日志")]
            LOG_MANAGER = 9,

            [Name("业务报表")]
            REPORT_MANAGER = 10,

            [Name("产品资料")]
            PRODUCT_MANAGER = 11,
        }

        public enum STATUS_ON_OFF
        {
            [Name("禁用")]
            OFF = 0,

            [Name("启用")]
            ON = 1
        }

        public enum STATUS_YES_NO
        {
            [Name("是")]
            OFF = 0,

            [Name("否")]
            ON = 1
        }

        [Name("SYS_LOGINSTATE")]
        public enum SYS_LOGINSTATE
        {
            [Name("在线")]
            ON_LINE = 1,

            [Name("离线")]
            OFF_LINE = 2,
        }

        public enum SYS_WEB_CONTROLL_TYPE
        {
            [Name("数据表格")]
            DATATABLE = 1,

            [Name("文本框")]
            INPUT_TEXT = 2,

            [Name("多行文本框")]
            INPUT_TEXTAREA = 3,

            [Name("密码框")]
            INPUT_PASSWORD = 4,

            [Name("点击按钮")]
            INPUT_BUTTON = 5,

            [Name("下拉列表")]
            SELECT = 6,

            [Name("复选按钮")]
            CHECKBOX = 7,

            [Name("单选按钮")]
            RADIO = 8,

            [Name("数据表格列")]
            DATATABLE_COLUNM = 9,

            [Name("控件面板")]
            PANEL = 10,

            [Name("页面权限")]
            PAGE = 11,

            [Name("部门列表")]
            DEPARTMENT_COMBO = 12,

            [Name("员工列表")]
            EMPLOYEE_COMBO = 13,
            [Name("Department_Employee")]
            Department_Employee=15,
            [Name("Html控件")]
            HTML = 14
        }

        public enum ORGANIZATION
        {
            [Name("九凤")]
            JOFUNG = 1,

            [Name("朵拉")]
            DUOLA = 2,

            [Name("莱迪")]
            LAIDI = 3,

            [Name("养健宝")]
            YJB = 4,

            [Name("美齐")]
            MQ = 5
        }

        public enum DEPARTMENT_ROLE
        {
            [Name("一线销售")]
            SALES_DEPARTMENT = 1,

            [Name("二线客服")]
            CUSTOMER_SERVICE_DEPARTMENT = 2,

            [Name("售后部门")]
            SALES_CUSTOMER_SERVICE_DEPARTMENT = 3,

            [Name("职能部门")]
            FUNCTIONAL_DEPARTMENT = 4,

            [Name("三线VIP客服")]
            VIP_SUSTOMER_SERIVCE_DEPARTMENT = 5,
        }

        public enum PRODUCT_DEPARTMENT_ROLE
        {
            [Name("一线销售")]
            SALES_DEPARTMENT = 1,

            [Name("二线客服")]
            CUSTOMER_SERVICE_DEPARTMENT = 2,

            [Name("一二线共有")]
            SALES_AND_SUSTOMER_SERIVCE_DEPARTMENT = 3,

            [Name("秀曼事业部")]
            XIU_MAN_DEPARTMENT = 4,

            [Name("美齐事业部")]
            MQ_DEPARTMENT = 5
        }

        public enum TELE_SYS_TYPE
        {
            [Name("请选择")]
            UNDEFING = -1,

            [Name("讯　呼")]
            FASTCALL = 1,

            [Name("深海捷")]
            MIXCALL = 2
        }

        public enum SEX
        {
            [Name("男")]
            MALE = 0,

            [Name("女")]
            FEMALE = 1,
        }

        public enum EMPLOYEE_STATUS
        {
            [Name("在职")]
            SERVING = 1,

            [Name("离职")]
            LEAVED = 0,
        }

        public enum PRODUCT_USAGE
        {
            [Name("内用")]
            EXTERNAL = 4,

            [Name("外用")]
            INTERNAL = 5,

            [Name("待定")]
            PENDING = 11,
        }

        public enum PRODUCT_PROPERTY
        {
            [Name("单品")]
            SINGLE_ITEM = 1,

            [Name("套装")]
            PACKAGE = 2
        }

        public enum ORDER_STATUS
        {
            [Name("下  单")]
            CREATE = 1,

            [Name("确  认")]
            CONFIRM = 2,

            [Name("批  准")]
            APPROVE = 3,

            [Name("已发货")]
            SHIPPED = 4,

            [Name("批准退货")]
            RETURNED = 5,

            [Name("收  货")]
            VERIFY_DELIVERY = 6,

            [Name("退货待入仓")]
            WAREHOUSING = 7,

            [Name("完  成")]
            FINISH = 8,

            [Name("记  账")]
            ACCOUNTING = 9,

            [Name("废弃单")]
            DISUSE = 11,

            [Name("丢失单")]
            LOST = 12,

            [Name("撤销单")]
            CANCEL = 13,

            [Name("删除单")]
            DELETED = 15,

            [Name("缺货登记")]
            LACK = 17,

            [Name("取消确认")]
            CANCEL_APPROVAL = 18,

            [Name("打包待发货")]
            READYSHIPPED = 19,

            [Name("申请撤销")]
            CANCEL_APPLY = 20,

            [Name("退货入库")]
            RETURNED_WAREHOUSING = 21,
        }

        public enum ORDER_STATUS_Employee_Report
        {
            [Name("下  单")]
            CREATE = 1,

            [Name("确  认")]
            CONFIRM = 2,

            [Name("批  准")]
            APPROVE = 3,

            [Name("发  货")]
            SHIPPED = 4,

            [Name("收  货")]
            VERIFY_DELIVERY = 5,

            [Name("退  货")]
            WAREHOUSING = 6

        }

        //public enum EXPECTED_EXPRESS
        //{
        //    [Name("待定")]
        //    UNKONW = 11,

        //    [Name("EMS不代收")]
        //    EMS_BDS = 12,

        //    [Name("宅急送")]
        //    ZJS = 13,

        //    [Name("顺丰")]
        //    SF = 14,

        //    [Name("申通快递")]
        //    STKD = 17,

        //    [Name("韵达快运")]
        //    YDKD = 18,

        //    [Name("联邦快递")]
        //    LBKD = 19,

        //    [Name("EMS代收")]
        //    EMS_DS = 21,

        //    [Name("联昊通")]
        //    LHT = 22,

        //    [Name("EMS国际件")]
        //    EMS_GJ = 24,

        //    [Name("绿色通道")]
        //    LSTD = 25,

        //    [Name("思迈")]
        //    MS = 26,

        //    [Name("优速")]
        //    YS = 27,

        //    [Name("圆通快递")]
        //    YTKD = 28,

        //    [Name("省内邮政(遇春)")]
        //    SNYZ_YC = 29,

        //    [Name("省外邮政(遇春)")]
        //    SYYZ_YC = 30,

        //    [Name("宅急送(九)")]
        //    ZJS_NINE = 31,

        //    [Name("顺丰（九）")]
        //    SHUNFENG9 = 33,

        //    [Name("速尔快递")]
        //    SUER = 35,

        //    [Name("圆通代收")]
        //    YUSNTONG = 36,

        //    [Name("圆通速递VIP(Taobao)")]
        //    YTSDVIP_TB = 37,

        //    [Name("韵达快递(Taobao)")]
        //    YDSD_TB = 38
        //}

        //public enum PAYMENT_TYPE
        //{
        //    [Name("待定")]
        //    UNDETERMINED = -1,

        //    [Name("货到付款")]
        //    HDFK = 1,

        //    [Name("支付宝")]
        //    ZFB = 2,

        //    [Name("网银")]
        //    WY = 3,

        //    [Name("待定")]
        //    DD = 4,

        //    [Name("代收")]
        //    DS = 6,

        //    [Name("不代收")]
        //    BDS = 7,

        //    [Name("绿色通道")]
        //    LSTD = 8,

        //    [Name("中行")]
        //    ZGYH = 9,

        //    [Name("农行")]
        //    NYYH = 10,

        //    [Name("工行")]
        //    GSYH = 11,

        //    [Name("招商")]
        //    ZSYH = 12,

        //    [Name("交行")]
        //    JTYH = 13,

        //    [Name("邮政")]
        //    YZYH = 14,

        //    [Name("建行")]
        //    JSYH = 15,

        //    [Name("农商银行")]
        //    NSYH = 16,

        //    [Name("先付订金+余额代收款")]
        //    DJ_AND_YE = 17,

        //    [Name("月结")]
        //    MONTH_PAY = 18
        //}

        //public enum ORDER_TYPE
        //{
        //    [Name("新单")]
        //    ORDER_NEW = 1,

        //    [Name("旧单")]
        //    ORDER_OLD = 2,

        //    [Name("补发单")]
        //    ORDER_REISSUE = 3,

        //    [Name("重发单")]
        //    ORDER_RESENT = 4,

        //    [Name("淘单")]
        //    OEDER_WASH = 5,
        //}

        public enum ORDER_PLATFORM
        {
            [Name("400热线")]
            PLATFORM_400 = 1,

            [Name("53")]
            PLATFORM_53 = 2,

            [Name("后台下单")]
            PLATFORM_PHONIX = 3,

            [Name("淘单")]
            PLATFORM_WASH = 4,

            [Name("客服专用")]
            PLATFORM_CUSTOMER_SERVICE = 5,

            [Name("QQ")]
            PLATFORM_QQ = 6,

            [Name("企业QQ")]
            PLATFORM_COMPANY_QQ = 7,

            [Name("淘宝")]
            PLATFORM_TAOBAO = 8,

            [Name("美齐商城")]
            PLATFORM_MEIQI = 9,

            [Name("美齐药妆店")]
            PLATFORM_MEIQI_TAOBAO = 10,

            [Name("莎曼莉旗舰店")]
            PLATFORM_MEIQI_TIANMAO = 11
        }

        public enum NUMBER_TYPE
        {
            [Name("手机号码")]
            CMCC = 1,

            [Name("固定电话")]
            CU = 2
        }

        //public enum FOLLOW_UP_STATUS
        //{
        //    [Name("当天跟进")]
        //    CURRENT_FOLLOW = 2,

        //    [Name("等退货")]
        //    WAITING_RETURN = 3,

        //    [Name("发往异常")]
        //    ERROR_SEND = 4,

        //    [Name("发往中")]
        //    SENDING = 5,

        //    [Name("反馈处理中")]
        //    RECIVE_FOLLOWING = 6,

        //    [Name("货到当地")]
        //    ORDER_TO_PLACE = 7,

        //    [Name("急件处理")]
        //    FAST_ORDER = 8,

        //    [Name("联系不上客户")]
        //    CAN_NOT_FIND_CUSTOMER = 9,

        //    [Name("上月签收业绩")]
        //    LAST_MONTH = 10,

        //    [Name("网签")]
        //    NET_GET = 11,

        //    [Name("业务告知签收")]
        //    TELL_CUSTOMER = 12,

        //    [Name("邮局联系不上")]
        //    EXPRESS_CAN_NOT_FIND_CUSTOMER = 13,

        //    [Name("致电客户收货")]
        //    CALL_CUSTOMER_GET_ORDER = 14,

        //    [Name("担保签收")]
        //    ORTHER_GET = 15,

        //    [Name("客户拒收")]
        //    CONFUSE_GET = 49,

        //    [Name("仓库缺货,货还未发")]
        //    NO_PRODUCT = 50,

        //    [Name("延迟收货")]
        //    LATE_SEND = 52
        //}

        //public enum REASON_FOR_REOPEN
        //{
        //    [Name("嫌价格贵")]
        //    PRICE_TO_HIGH = 1,

        //    [Name("担心效果")]
        //    WORRY_ABOUT_EFFECT = 2,

        //    [Name("怕有副作用")]
        //    WORRY_ABOUT_BAY_FOR_BODY = 3,

        //    [Name("无")]
        //    NONE = 4,

        //    [Name("与家人商量")]
        //    TALK_WITH_FAMILY = 5,

        //    [Name("在外出差")]
        //    OUT_OF_PALCE = 6,

        //    [Name("无人接听")]
        //    NOBODY_LISTEN = 7,

        //    [Name("停机")]
        //    PHONE_STOP = 8,

        //    [Name("空号")]
        //    PHONE_EMPTY = 9,

        //    [Name("无通")]
        //    CAN_NOT_CONNECT = 10,

        //    [Name("已成交")]
        //    DUE = 11,

        //    [Name("订单待发")]
        //    ORDER_WATING_FOR_SEND = 12,

        //    [Name("不承认")]
        //    NOT_GET = 13,

        //    [Name("不需要")]
        //    NO_NEED = 14,

        //    [Name("别家售后")]
        //    BUY_IN_ORHER_PALCE = 15,
        //}

        //public enum RETURN_REASON
        //{
        //    [Name("联系不上（关机、停机、无人接听、挂机、联系不上本人）")]
        //    CAN_NOT_FIND = 2,

        //    [Name("否认订购、恶意订购")]
        //    BADLY_BUY = 3,

        //    [Name("客户没钱拒收")]
        //    NO_MONEY = 4,

        //    [Name("负面影响拒收")]
        //    BAD_IMAGE = 5,

        //    [Name("验货拒收")]
        //    CHECK_PRODUCT = 6,

        //    [Name("对产品质疑拒收")]
        //    DO_NOT_BELIVE = 7,

        //    [Name("收到与订购产品内容不符拒收")]
        //    NOT_THE_SAME = 8,

        //    [Name("直接拒收无反馈原因")]
        //    NO_REASON = 9,

        //    [Name("快递保留超时自返")]
        //    STAY_TO_LONG = 10,

        //    [Name("快递服务问题（没联系派送、态度差、无法代收、转错地址、不给拆包、未到当地退回、站点暂停、丢件）")]
        //    EXPRESS_BAY = 11,

        //    [Name("快递超区")]
        //    EXPRESS_NOT_IN_AREA = 12,

        //    [Name("发票、收据问题")]
        //    NO_RECIVE = 13,

        //    [Name("错发、少发、重复发货")]
        //    PRODUCT_WARING = 14,

        //    [Name("与核对签收后网上显示退货、丢件")]
        //    NET_MISSED = 15,

        //    [Name("客户未确定订购的")]
        //    NOT_CONFIRM_BUY = 16,

        //    [Name("发货后客户要求取消订单")]
        //    CANCEL_AFTER_SEND = 17,

        //    [Name("泄单、抢单")]
        //    ERROR_ORDER = 18,

        //    [Name("外包装不好、破损、受潮等产品问题")]
        //    PRODUCT_QUNATITY = 19,

        //    [Name("更改套餐、地址等")]
        //    CHANGE_INFO = 20,

        //    [Name("客户一直拖延着不去取货")]
        //    NO_BODY_GET = 22,

        //    [Name("客户在外地、出差，导致收不了货，不要了")]
        //    CUSTOMER_NOT_IN_TARGET_PLACE = 23,

        //    [Name("客户因其它原因一直都不收货，快递超时退回了")]
        //    OHTER = 24,

        //    [Name("货在仓库，还未发出，已经生成快递单号，销售告知客户不要货的")]
        //    NOT_SENT_CUSTOMER_CANCEL = 25,

        //    [Name("销售下错地址")]
        //    WRONG_ADDRESS = 26,

        //    [Name("审单员失误造成的退货")]
        //    CONFIRM_ERROR = 27,

        //    [Name("停机、关机")]
        //    PHONE_SHOTDOWN = 28,

        //    [Name("重发单")]
        //    RESEND_ORDER = 29,

        //    [Name("联系不上客户，快递保留超时退回")]
        //    CAN_NOT_FIND_TIME_OUT = 30,
        //}

        //public enum CUSTOMER_COMPLAINT_TYPE
        //{
        //    [Name("催指导")]
        //    REMINDERS_GUIDANCE = 1,

        //    [Name("效果问题")]
        //    INEFFECTIVE = 2,

        //    [Name("产品质量问题")]
        //    PRODUCT_QUALITY_PROBLEMS = 3,

        //    [Name("仓库发货问题")]
        //    WAREHOUSE_DELIVERY_PROBLEMS = 4,

        //    [Name("销售下错单")]
        //    SALES_UNDER_THE_WRONG_ONE = 5,

        //    [Name("联系不上销售")]
        //    NOT_CONTACT_SALES = 6,

        //    [Name("防伪查询")]
        //    SECURITY_CHECK = 7,

        //    [Name("资料外泄")]
        //    DATA_LEAKAGE = 8,

        //    [Name("维护客户")]
        //    MAINTAINING_CUSTOMER = 9,

        //    [Name("投诉315指导")]
        //    COMPLAINTS_GUIDANCE_315 = 10,

        //    [Name("其它")]
        //    OTHER = 11,
        //}

        public enum FOLLOW_UP_TYPE
        {
            [Name("客户跟进")]
            CUSTOMER_FOLLOW = 1,

            [Name("订单跟进")]
            ORDER_FOLLOW = 2,

            [Name("客户投诉")]
            CUSTOMER_COMPLAINT = 3,

            [Name("客户代办")]
            CUSTOMER_AGENT = 4,

            [Name("投诉请求")]
            CUSTOMER_COMPLAINT_REQUEST = 5,

            [Name("快递单跟进")]
            EXPRESS_FOLLOW_UP = 6
        }

        public enum FOLLOW_UP_TITLE
        {
            [Name("快速跟进")]
            QUICK_FOLLOW = 1
        }

        public enum WORK_FLOW_TYPE
        {
            [Name("跟单流程")]
            ORDER_FOLLOW = 1
        }

        public enum CONTROL_WRH
        {
            [Name("隐藏")]
            HIDDEN = 1,

            [Name("只读")]
            READ_ONLY = 2,

            [Name("读写")]
            READ_WRITE = 3,
        }

        public enum PHONE_RULE
        {
            [Name("无效")]
            INVALID = 0,

            [Name("首选")]
            FIRST = 1,

            [Name("短信")]
            SMS = 2,

            [Name("有效")]
            VALID = 3
        }

        public enum OPERATION_TYPE
        {
            [Name("添加操作")]
            Insert = 1,

            [Name("更新操作")]
            Update = 2,

            [Name("删除操作")]
            Delete = 3,

            [Name("工资单审批")]
            Saler_Bill_Approve = 4
        }

        public enum CALL_CDR_MONITOR_GRADE
        {
            [Name("很差")]
            VeryBad = 1,

            [Name("差")]
            Bad = 2,

            [Name("合格")]
            Eligibility = 3,

            [Name("良好")]
            Good = 4,

            [Name("优秀")]
            Fine = 5,
        }

        public enum CALL_CDR_MONITOR_ESTIMATE_TYPE
        {
            [Name("虚构并使用具有国家资质认可身份的人员进行销售")]
            ESTIMATETYPE1 = 1,

            [Name("虚构故事或捏造事实进行诱导顾客的行为")]
            ESTIMATETYPE2 = 2,

            [Name("以恐吓等其他行为方式逼迫顾客的行为")]
            ESTIMATETYPE3 = 3,

            [Name("电话或短信中对顾客无理")]
            ESTIMATETYPE4 = 4,

            [Name("在销售过程中涉及到药、处方、药房、调配等字眼")]
            ESTIMATETYPE5 = 5,

            [Name("要求顾客追加消费金额")]
            ESTIMATETYPE6 = 6,

            [Name("给顾客承诺私人承诺")]
            ESTIMATETYPE7 = 7,

            [Name("销售人员谎称经历")]
            ESTIMATETYPE8 = 8,

            [Name("宣称通过图片可用仪器做检测")]
            ESTIMATETYPE9 = 9,

            [Name("投诉315宣导产品由保险公司承保或配送包裹内附有保险单")]
            ESTIMATETYPE10 = 10,

            [Name("逼迫顾客去借高利贷或卖房、卖车等行为")]
            ESTIMATETYPE11 = 11,

            [Name("拒接顾客电话或不回短信")]
            ESTIMATETYPE12 = 12,

            [Name("销售过程中冒用国家职能部门")]
            ESTIMATETYPE13 = 13,

            [Name("未作铺垫")]
            ESTIMATETYPE14 = 14,

            [Name("虚构并使用具有国家资质认可身份的人员进行销售，如：医生、主任医师、药物总监、教授、导师、院长等； ")]
            ESTIMATETYPE15 = 15,

            [Name("（七）给顾客承诺无效退款、返款，个人垫付或承担一半的治疗费用等")]
            ESTIMATETYPE16 = 16,

            [Name("虚拟或宣导销售人员有出国或某医院、研究院工作的经历等行为")]
            ESTIMATETYPE17 = 17,

            [Name("所有销售部门人员不允许教客户使用方法")]
            ESTIMATETYPE18 = 18,

            [Name("客服人员禁止踩销售部门的产品")]
            ESTIMATETYPE19 = 19,

            [Name("禁止与客户建立恋爱关系、欺骗客户情感")]
            ESTIMATETYPE20 = 20,

            [Name("销售人员在销售过程中禁止留自己的私人电话、QQ、邮箱等联系方式给客户")]
            ESTIMATETYPE21 = 21,

            [Name("宣导产品是进口的 ")]
            ESTIMATETYPE22 = 22,

            [Name("销售人员把公司详细地址告诉客户")]
            ESTIMATETYPE23 = 23,

            [Name("禁止向客户索取电话号码、qq号码等各种联系方式")]
            ESTIMATETYPE24 = 24,

            [Name("引导客户投诉")]
            ESTIMATETYPE25 = 25,

            [Name("引导客户拿产品去检验，有激素等可以索取相应赔偿")]
            ESTIMATETYPE26 = 26,

            [Name("销售过程中不得涉及二线相关专业话术")]
            ESTIMATETYPE27 = 27,

            [Name("在Y3系统里面登记客联系方式")]
            ESTIMATETYPE28 = 28,

            [Name("禁止承诺客户后期无需再花任何一分钱等词意和话术")]
            ESTIMATETYPE29 = 29,

            [Name("禁止宣导为客户调制、调配产品，或量身订制产品")]
            ESTIMATETYPE30 = 30,

            [Name("禁止以需要交关税为由让顾客增加消费金额，或产品少某一成份为由追加货款，或不给客户发货客户要求退款，无法退款为要挟让客户追加货款，或多发产品为由让客户追加货款等行为")]
            ESTIMATETYPE31 = 31,

            [Name("其他")]
            ESTIMATETYPE32 = 32
        }

        public enum CacheItemName
        {
            [Name("员工缓存")]
            EmployeeCache = 1,

            [Name("客户意向缓存")]
            CustomerIntentionCache = 2,

            [Name("客户来源缓存")]
            CustomerOriginCache = 3,

            [Name("进线渠道缓存")]
            InLineChannelCache = 4,

            [Name("部门缓存")]
            DepartmentCache = 5,

            [Name("产品缓存")]
            ProductCache = 6,

            [Name("系统模块页")]
            SystemModulePage = 7,

            [Name("产品供应商")]
            ProductSupplierCache = 8,

            [Name("产品类型")]
            ProductTypeCache = 9,

            [Name("区域缓存")]
            AreasCache = 10,

            [Name("城市缓存")]
            CitysCache = 11,

            [Name("省份缓存")]
            ProvinceCache = 12,

            [Name("固话区域缓存")]
            PhoneAreaCache = 13,

            [Name("未成交原因缓存")]
            CustomerUnsoldReasonCache = 14,

            [Name("短号匹配缓存")]
            ShortNumberMappingCache = 15,

            [Name("约单原因缓存")]
            CustomerUncontactReasonCache = 16,

            [Name("退货原因缓存")]
            CustomerReturnReasonCache = 17,

            [Name("客户投诉类型缓存")]
            CustomerComplaintTypeCache = 18,

            [Name("客户等级缓存")]
            CustomerGradeCache = 19,

            [Name("付款方式缓存")]
            PaymentTypeCache = 20,

            [Name("活动促销类型缓存")]
            ProductPromtConfgCache = 21,

            [Name("订单类型缓存")]
            OrderTypeCache = 22, 

            [Name("订单平台缓存")]
            OrderPlatformCache = 23,

            [Name("跟进状态缓存")]
            FollowUpStatusCache = 24,

            [Name("快递公司缓存")]
            ExpressCompanyCache = 25,

            [Name("订单备注类型缓存")]
            OrderRemarkTypeCache = 26
        }

        public enum BILL_PAY_TYPE
        {
            [Name("月结")]
            MONTHLY_PAYMENT = 1,
        }

        public enum BILL_APPROVE_STATUS
        {
            [Name("未审核")]
            UNAPPROVE = 0,

            [Name("同意")]
            AGREE = 1,

            [Name("不同意")]
            NOT_AGREE = 2
        }

        public enum STOCK_TYPE
        {
            [Name("采购入库")]
            PurchaseStoreIn = 1,

            [Name("退货入库")]
            ReturnStoreIn = 2,

            [Name("其他入库")]
            OtherStoreIn = 3,

            [Name("采购出库")]
            PurchaseStoreOut = 4,

            [Name("销售出库")]
            SalerStoreOut = 5,

            [Name("其他出库")]
            OtherStoreOut = 6,

            [Name("退货待入库")]
            ReturnStayStoreIn = 7,

            [Name("退货报损")]
            ReturnLoss = 8,

            [Name("退货报缺")]
            ReturnMissing = 9
        }

        public enum BILL_STATUS
        {
            [Name("新增单")]
            New = 1,

            [Name("等待审批")]
            None = 2,

            [Name("正在审批")]
            Auditing = 3,

            [Name("审批通过")]
            Audit = 4,

            [Name("执行完毕")]
            Finish = 5,

            [Name("已撤销")]
            Cancel = 6,

            [Name("已作废")]
            Invalid = 7,

            [Name("审批未通过")]
            NotPassed = 8
        }

        public enum STOCK_UOM
        {
            [Name("个")]
            Peace = 1,

            [Name("袋")]
            Bag = 2,

            [Name("包")]
            Package = 3,

            [Name("盒")]
            Box = 4,

            [Name("箱")]
            Chest = 5
        }

        public enum WAREHOUSE
        {
            [Name("默认仓库")]
            DefaultWareHouse = 1
        }

        public enum BILL_TYPE
        {
            [Name("采购单")]
            BILL_PURCHASE = 1,

            [Name("入库单")]
            STORE_IN = 2,

            [Name("出库单")]
            STORE_OUT = 3,
            [Name("工资单")]
            EmploySalary = 4
        }

        public enum PERMISSION_DEPT_KEY
        {
            [Name("创建人部门")]
            CREATOR_DEPARTMENT = 1,

            [Name("销售员部门")]
            SALER_DEPARTMENT = 2,

            [Name("跟进人部门")]
            FOLLOW_UP_DEPARMENT = 3
        }

        public enum PERMISSION_RULE_ID
        {
            [Name("自己")]
            SELF = 1,

            [Name("本部门")]
            SELF_DEPARTMENT = 2,

            [Name("一线销售")]
            SALES_DEPARTMENT = 4,

            [Name("二线客服")]
            CUSTOMER_SERVICE_DEPARTMENT = 8
        }

        public enum PROMPT_TYPE
        {
            [Name("满X(元)送")]
            MEET_SPECIAL_AMOUNT = 1,

            [Name("买M送N")]
            BUY_M_GIVE_N = 2,

            [Name("买就送")]
            BUY_THEN_GIVE = 3
        }

    }
}