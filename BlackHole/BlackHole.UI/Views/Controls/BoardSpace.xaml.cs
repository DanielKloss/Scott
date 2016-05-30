using BlackHole.UI.Helpers;
using BlackHole.UI.Models;
using BlackHole.UI.ViewModels;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlackHole.UI.Views.Controls
{
    public sealed partial class BoardSpace : UserControl
    {
        public BoardSpace()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty spaceIdProperty = DependencyProperty.Register("SpaceId", typeof(string), typeof(BoardSpace), new PropertyMetadata(""));
        public string SpaceId
        {
            get { return (string)GetValue(spaceIdProperty); }
            set { SetValue(spaceIdProperty, value); }
        }

        public static readonly DependencyProperty containingPieceProperty = DependencyProperty.Register("ContainingPiece", typeof(Piece), typeof(BoardSpace), new PropertyMetadata(new Piece()));
        public Piece ContainingPiece
        {
            get { return (Piece)GetValue(containingPieceProperty); }
            set { SetValue(containingPieceProperty, value); }
        }

        public static readonly DependencyProperty isBlackHoleProperty = DependencyProperty.Register("IsBlackHole", typeof(bool), typeof(BoardSpace), new PropertyMetadata(false));
        public bool IsBlackHole
        {
            get { return (bool)GetValue(isBlackHoleProperty); }
            set { SetValue(isBlackHoleProperty, value); }
        }

        public static readonly DependencyProperty isSurroundingProperty = DependencyProperty.Register("IsSurrounding", typeof(bool), typeof(BoardSpace), new PropertyMetadata(false));
        public bool IsSurrounding
        {
            get { return (bool)GetValue(isSurroundingProperty); }
            set { SetValue(isSurroundingProperty, value); }
        }

        private async void control_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var piece = await e.DataView.GetTextAsync();
                var pieceComponents = piece.Split(',');

                ContainingPiece = new Piece();
                ContainingPiece.player = Convert.ToInt32(pieceComponents[0]);
                ContainingPiece.pieceValue = Convert.ToInt32(pieceComponents[1]);

                AnimationHelper.ScaleUpAnimation(boardPiece).Begin();

                ((GameViewModel)DataContext).StartNextTurn(ContainingPiece);
            }

            e.Handled = true;
        }

        private void control_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.DragUIOverride.IsCaptionVisible = false;
                e.DragUIOverride.IsGlyphVisible = false;
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }
    }
}
