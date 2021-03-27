using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class RandColor : MonoBehaviour
{
	public GameObject curObj; //current gameObject
	private Renderer ren; 
	public float alpha = 0.2f;//set transparency via the alpha value
	private Material curMat; //current material

    void Start()
    {
		ren = this.GetComponent<Renderer>();
        ren.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //pick a random color for the cube
		curObj = gameObject;
		curMat = curObj.GetComponent<Renderer>().material;
	}


	void Update()
    {
		Material material = ren.material;
		ChangeMode(material); //change blend mode to transparent
		ChangeAlpha(curMat, alpha);//change the alpha value
	}
	

	
	//method that changes the color alpha value of a given material
	void ChangeAlpha(Material mat,float alphaVal)
	{
		Color oldCol = mat.color;
		Color newCol = new Color(oldCol.r,oldCol.g,oldCol.b,alphaVal);
		mat.SetColor("_Color",newCol);
	}
	
	
	//helper method that's able to assign the values of the transparent mode included in StandardShaderGUI at runtime
	void ChangeMode(Material standardShaderMaterial)
	{
		standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
		standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        standardShaderMaterial.SetInt("_ZWrite", 0);
        standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
        standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
        standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        standardShaderMaterial.renderQueue = 3000;
	}
	
}
