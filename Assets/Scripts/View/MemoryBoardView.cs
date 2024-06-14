using MemoryGame.Model;
using System.ComponentModel;
using UnityEngine;

namespace MemoryGame.View
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoardModel>
    {
        private Vector3 offsetVector = new Vector3(-2.5f, 0, -2.5f);

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.Log("Property Changed");
        }

        public void SetUpMemoryBoardView(MemoryBoardModel model, GameObject tilePrefab)
        {
            foreach (TileModel tile in model.TileModels)
            {
                //version from jef:
                //float offsetX = -(model.Columns / 2 - 0.5f + 0.25f) * tilePrefab.transform.localScale.x;
                //float offsetY = -(model.Rows / 2 - 0.5f + 0.25f) * tilePrefab.transform.localScale.x;

                Vector3 pos = offsetVector + (new Vector3(tile.Row, 0, tile.Column /** -offsetVector.z*/) * -offsetVector.x);
                Quaternion rotation = Quaternion.Euler(0, 180, 0);
                GameObject instantiatedCard = Instantiate(tilePrefab, pos, rotation, parent: this.gameObject.transform);

                TileView tileView = instantiatedCard.GetComponent<TileView>();
                if (tileView != null)
                {
                    tileView.Model = tile;
                }
            }

        }
    }
}