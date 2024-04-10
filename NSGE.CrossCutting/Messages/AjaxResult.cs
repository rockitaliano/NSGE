namespace NSGE.CrosCutting.Messages
{
    public class AjaxResult<T> where T : class
    {
        #region OLD version não alterar

        private bool _success;

        public bool Success
        {
            get
            {
                return _success;
            }
            set
            {
                _success = value;

                if (_success)
                {
                    MessageError = "";
                    Message = "Operação realizada com sucesso";
                }
            }
        }

        public string Message { get; set; }
        public string MessageError { get; set; }
        public T Model { get; set; }

        public void SetarErro(string msg)
        {
            _success = false;
            MessageError = Message = msg;
        }

        public void SetarSucesso(string msg)
        {
            _success = true;
            MessageError = Message = msg;
        }

        public AjaxResult()
        {
            MessageError = "Ocorreu um erro no sistema, tente novamente";
        }

        public AjaxResult(T entidade)
            : this()
        {
            Model = entidade;
        }

        #endregion OLD version não alterar

        private T result;
        private bool success;
        private string message;

        public AjaxResult<T> SetResult(T result)
        {
            this.result = result;

            return this;
        }

        public AjaxResult<T> SetSuccess()
        {
            this.success = true;

            return this;
        }

        public AjaxResult<T> SetError()
        {
            this.success = false;

            return this;
        }

        public AjaxResult<T> SetMessage(string msg)
        {
            this.message = msg;

            return this;
        }

        public object Return()
        {
            return new
            {
                success = success,
                message = message,
                result = result,
            };
        }
    }
}