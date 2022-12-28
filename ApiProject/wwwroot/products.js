/// <reference path="home.js" />
addToBag = (product) => {
    //let prodString = JSON.stringify(product)
    let bag = sessionStorage.getItem("bag")
    let theBag = JSON.parse(bag)
    theBag.push(product)
    let thebagString = JSON.stringify(theBag)
    sessionStorage.setItem("bag", thebagString)
    let itemsCountText = document.getElementById("ItemsCountText")
    itemsCountText.innerHTML = parseInt(itemsCountText.innerText) + 1


}
drawCategory = (category) => {

    var temp = document.getElementById("temp-category");
    var clone = temp.content.cloneNode(true)
    clone.querySelector(".opt").id = category.id
    clone.querySelector(".opt").value = category.id
    clone.querySelector(".OptionName").innerText = category.name
    clone.querySelector(".opt").addEventListener("change", filterProducts)
    document.getElementById("categoryList").appendChild(clone)


}


drawCategories = (ans2) => {
    for (var i = 0; i < ans2.length; i++) {
        drawCategory(ans2[i])
    }
    console.log(ans2[1].name)
}

drawProduct = (product) => {
    var temp = document.getElementById("temp-card");
    var clone = temp.content.cloneNode(true)
    clone.querySelector("h1").innerText = product.name
    clone.querySelector(".category").innerText = product.categoryId//name!!!
    clone.querySelector(".description").innerText = product.description
    clone.querySelector(".price").innerText = product.price
    clone.querySelector("img").src = `../img/${product.imgUrl}`
    clone.querySelector("button").addEventListener("click", () => addToBag(product))
    document.body.appendChild(clone)

}
removeProducts = () => {   

    let products = document.getElementsByClassName("card")

    for (var i = products.length - 1; i >= 0; i--) {
        console.log(products[i])
        document.body.removeChild(products[i])
    }

}
drawProducts = (ans2) => {
    removeProducts()
    for (var i = 0; i < ans2.length; i++) {
        drawProduct(ans2[i])
    }

}
getCategories = async () => {
    const url = `https://localhost:44368/Api/Category`;
    const ans = await fetch(url);
    if (ans.ok) {
        let ans2 = await ans.json()
        console.log(ans2)
        drawCategories(ans2)

    }
}
getProducts = async (url) => {
    const ans = await fetch(url);
    if (ans.ok) {
        let ans2 = await ans.json()
    
        drawProducts(ans2)
        document.getElementById("counter").innerHTML = ans2.length
    }



}
filterProducts = () => {

    let url = `https://localhost:44368/Api/Product`;

    let d = document.getElementsByTagName("input");
    let flag = false;
    for (var i = 0; i < d.length; i++) {
        if (d[i].type == "checkbox" && d[i].checked) {
            if (!flag) {
                url = url + "?categoryId=" + d[i].id
                flag = true
            }
            else
                url = url + "&categoryId=" + d[i].id
        }
        else if (d[i].id == "minPrice" && d[i].value) {
            if (!flag) {
                url = url + "?fromPrice=" + d[i].value
                flag = true
            }
            else
                url = url + "&fromPrice=" + d[i].value
        }
        else if (d[i].id == "maxPrice" && d[i].value) {
            if (!flag) {
                url = url + "?toPrice=" + d[i].value
                flag = true
            }
            else
                url = url + "&toPrice=" + d[i].value
        }
        else if (d[i].id == "nameSearch" && d[i].value) {
            if (!flag) {
                url = url + "?name=" + d[i].value
                flag = true
            }
            else
                url = url + "&name=" + d[i].value
        }
    }


    getProducts(url)
}

window.addEventListener("load", getProducts("https://localhost:44368/Api/Product"))
window.addEventListener("load", getCategories())
window.addEventListener("load", () => {
    let bag = []
    theBag = JSON.stringify(bag);
    sessionStorage.setItem("bag",theBag)

})