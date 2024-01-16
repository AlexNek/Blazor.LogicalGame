namespace LogicalGame.Client.Pages
{
    public partial class Game
    {
        private static readonly string?[,] _boardInit = new string?[,]
                                                            {
                                                            { "9", null, null, null, null, "2" },
                                                            { null,  "6", null, null, "1", null },
                                                            { null, null,"7" , "10", null, null },
                                                            { null, "4", null, null, "8", null },
                                                            { "5", null, null, null, null, "3" }
                                                            };

        private static readonly string?[,] _boardTarget = new string?[,]
                                                              {
                                                              { "1", null, null, null, null, "8" },
                                                              { null,  "2", null, null, "7", null },
                                                              { null, null,"3" , "6", null, null },
                                                              { null, "4", null, null, "10", null },
                                                              { "5", null, null, null, null, "9" }
                                                              };

        private Board? _board;


        private int GetColorIndex(int index)
        {
            if (_board != null)
            {
                string? valueByIndex = _board.GetValueByIndex(index);
                if (valueByIndex != null)
                {
                    return int.Parse(valueByIndex);
                }
            }

            return 0;
        }

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// Override this method if you will perform an asynchronous operation and
        /// want the component to refresh when that operation is completed.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            //_board = new Board(_boardTarget);
            _board = new Board(_boardInit);
        }

        private async Task RotageBigLeft()
        {
            await Task.CompletedTask;
            _board?.Rotate(Board.RotateGlobalLeft);
        }

        private async Task RotageBigRight()
        {
            await Task.CompletedTask;
            _board?.Rotate(Board.RotateGlobalRight);
        }

        private async Task RotateLeftTable()
        {
            await Task.CompletedTask;
            _board?.Rotate(Board.RotateLeftSide);
        }

        private async Task RotateRightTable()
        {
            await Task.CompletedTask;
            _board?.Rotate(Board.RotateRightSide);
        }

        private async Task Reset()
        {
            await Task.CompletedTask;
            _board = new Board(_boardInit);
        }

        private async Task Solution()
        {
            await Task.CompletedTask;
            _board = new Board(_boardTarget);
        }

    }
}