addToBag = (product) => {
    //localStorage.setItem(product.id, JSON.stringify(product))
}
drawProduct = (product) => {
    console.log(product.name)
    var temp = document.getElementById("temp-card");
    var clone = temp.content.cloneNode(true)
    clone.querySelector("h1").innerText = product.name
    clone.querySelector(".category").innerText = product.categoryId//name!!!
    console.log(product.categoryId)
    console.log(product.categoryId.name)
    clone.querySelector(".description").innerText = product.description
    clone.querySelector("img").src = `../img/${product.imgUrl}`
    clone.querySelector("button").addEventListener("click",()=> addToBag(product))
    document.body.appendChild(clone)

}
drawProducts = (ans2) => {
    for (var i = 0; i < ans2.length; i++) {
        drawProduct(ans2[i])
    }
    console.log(ans2[1].name)
}
getProducts=async()=>{
    const url = `https://localhost:44368/Api/Product`;
    const ans = await fetch(url);
    if (ans.ok) {
        let ans2 = await ans.json()
        console.log(ans2)
        console.log(ans2[0].name)
        drawProducts(ans2)
    }
}

window.addEventListener("load", getProducts())