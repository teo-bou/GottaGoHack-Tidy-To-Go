using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CromulentBisgetti.ContainerPacking;
public class CubePacking : MonoBehaviour
{

    public void Solution()
    {  Vector3 dimension = GameObject.Find("Data").GetComponent < Data >().dimension;
       List<Vector3> items = GameObject.Find("Data").GetComponent<Data>().items;
        int i = 1;
        System.Collections.Generic.List<CromulentBisgetti.ContainerPacking.Entities.Container> containers = new System.Collections.Generic.List<CromulentBisgetti.ContainerPacking.Entities.Container>();
        containers.Add(new CromulentBisgetti.ContainerPacking.Entities.Container((int)i, (decimal)dimension.x, (decimal)dimension.y, (decimal)dimension.z));
        i++;
        System.Collections.Generic.List<CromulentBisgetti.ContainerPacking.Entities.Item> itemsToPack = new System.Collections.Generic.List<CromulentBisgetti.ContainerPacking.Entities.Item>();
        
        foreach(Vector3 item in items)
        {
            itemsToPack.Add(new CromulentBisgetti.ContainerPacking.Entities.Item(i, (decimal)item.x, (decimal)item.y, (decimal)item.z, 1));

        }
        
        //itemsToPack.Add(new CromulentBisgetti.ContainerPacking.Entities.Item(2, 2, 3, 3, 4));
        //itemsToPack.Add(new CromulentBisgetti.ContainerPacking.Entities.Item(3, 7, 6, 3, 4));

        

        List<int> algorithms = new List<int>();
        algorithms.Add((int)CromulentBisgetti.ContainerPacking.Algorithms.AlgorithmType.EB_AFIT);



        System.Collections.Generic.List<CromulentBisgetti.ContainerPacking.Entities.ContainerPackingResult> result = PackingService.Pack(containers, itemsToPack, algorithms);


        foreach (var container in result)
        {

            //Debug.Log(container.ContainerID);
            // Debug.Log(container.AlgorithmPackingResults.PackedItems);

            foreach (var item in container.AlgorithmPackingResults[0].PackedItems)
            {
                //Vector3 pos = new Vector3((float)item.Dim1, (float)item.Dim2, (float)item.Dim3);
                //Debug.Log(((float)item.CoordX, (float)item.CoordY, (float)item.CoordZ));
                GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                box.transform.localScale = new Vector3((float)item.PackDimX, (float)item.PackDimY, (float)item.PackDimZ);
                box.transform.position = new Vector3((float)item.CoordX + (float)item.PackDimX / 2, (float)item.CoordY + (float)item.PackDimY / 2, (float)item.CoordZ + (float)item.PackDimZ / 2);
                box.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

            }
            foreach (var item in container.AlgorithmPackingResults[0].UnpackedItems)
            {
                Debug.Log((item.Dim1, item.Dim2, item.Dim3));
            }


        }
    }
}
