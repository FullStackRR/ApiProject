
drawOrderItem = (product, productIndex) => {
    let temp = document.getElementsByTagName("template")[0]
  
    var clone = temp.content.cloneNode(true)
   clone.querySelector(".itemName").innerText = product.name
   var t= clone.querySelector("img")
    t.src = `../img/${product.imgUrl}`
    clone.querySelector(".price").innerText = product.price
    clone.querySelector(".availabilityColumn").innerText = "✔במלאי?"
    //clone.querySelector(".image").style.setProperty("color", "red");
    //clone.querySelector(".image").style.setProperty("background - image", `url(../img/${ product.imgUrl }`);// background - image: url(../img/${ product.imgUrl })

    clone.querySelector(".DeleteButton").addEventListener("click", () => deleteItem(productIndex))
    document.getElementsByTagName("tbody")[0].appendChild(clone)

}

//<template id="temp-row">
//    <tr class="item-row">
//        <td class="imageColumn"><a rel="lightbox" href="#"><div class="image"></div></a></td>
//        <td class="descriptionColumn"><div><h3 class="itemName"></h3><h6><p class="itemNumber"></p><a class="viewLink" href="https://www.next.co.il/he/g59522s11#407223">לפרטים נוספים</a></h6></div></td>
//        <td class="availabilityColumn"><div>במלאי</div></td>
//        <td class="totalColumn delete"><div class="expandoHeight" style="height: 99px;"><p class="price"></p><a href="#" title="לחצו כאן כדי להסיר את פריט זה" class="Hide DeleteButton showText">הסרת פריט</a></div></td>
//    </tr>
//</template>
removeOrderItems = () => {
    let orderItems = document.getElementsByClassName("item-row");
    for (var i = orderItems.length - 1; i >= 0; i--) {
        document.getElementsByTagName("tbody")[0].appendChild(clone)    }

}
deleteItem = (productIndex) => {
    let orderJson = sessionStorage.getItem("bag")
    let order = JSON.parse(orderJson)
    let updatedOrder = []
    for (var i = 0; i < order.length; i++) {
        if (i != productIndex)
            updatedOrder.push(order[i])
    }
    updatedOrder = JSON.stringify(updatedOrder)
    sessionStorage.setItem("bag", updatedOrder)
    removeOrderItems()
    drawOrder()
}
drawOrder = () => {
    let orderJson = sessionStorage.getItem("bag")
    let order = JSON.parse(orderJson)
    for (var i = 0; i < order.length; i++) {
        drawOrderItem(order[i], i)
    }

}

serverCall = async (orderObject) => {
    const res = await fetch("https://localhost:44368/Api/Order",
        {
            headers: { "content-type": "application/json" },
            method: 'POST',
            body: JSON.stringify(orderObject)
        })
    if (res.ok) {
        const newOrder = await res.json()
        alert("הזמנתך נקלטה בהצלחה! תודה שקנית אצלינו")

    }
    else
        throw new Error("failed, please try later");
}

placeOrder = () => {
    let orderJson = sessionStorage.getItem("bag")
    let order = JSON.parse(orderJson)
    let orderItems = []
    let totalPrice = 0
    for (var i = 0; i < order.length; i++) {
        const orderItem = {
            "productId": order[i].id,
            "quantity": 1
        }
        orderItems.push(orderItem)
        totalPrice += order[i].price
    }
    let userId = JSON.parse(sessionStorage.getItem("details"))[0].id
    let orderObject = {
        "userId": userId,
        "date": new Date(),
        "totalPrice": totalPrice,

        "orderItems": orderItems
    }
    let orderString = JSON.stringify(orderObject)//
    localStorage.setItem("order", orderString)//
    serverCall(orderObject)
}


window.addEventListener("load", drawOrder())
