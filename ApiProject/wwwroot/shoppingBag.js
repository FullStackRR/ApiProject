
drawOrderItem = (product) => {
    var temp = document.getElementById("temp - row")
    //var clone = temp.content.cloneNode(true)
    //clone.querySelector(".itemName").innerText = product.name
    //clone.querySelector(".itemNumber").innerText = product.id
    ////clone.querySelector(".description").innerText = product.description
    ////clone.querySelector(".price").innerText = product.price
    ////clone.querySelector(".image").src = `../img/${product.imgUrl}`
    ///*clone.querySelector("button").addEventListener("click", () => addToBag(product))*/
    //document.body.appendChild(clone)
}

//<template id="temp-row">
//    <tr class="item-row">
//        <td class="imageColumn"><a rel="lightbox" href="#"><div class="image"></div></a></td>
//        <td class="descriptionColumn"><div><h3 class="itemName"></h3><h6><p class="itemNumber"></p><a class="viewLink" href="https://www.next.co.il/he/g59522s11#407223">������ ������</a></h6></div></td>
//        <td class="availabilityColumn"><div>�����</div></td>
//        <td class="totalColumn delete"><div class="expandoHeight" style="height: 99px;"><p class="price"></p><a href="#" title="���� ��� ��� ����� �� ���� ��" class="Hide DeleteButton showText">���� ����</a></div></td>
//    </tr>
//</template>

drawOrder = () => {
    let orderJson = sessionStorage.getItem("bag")
    let order = JSON.parse(orderJson)
    for (var i = 0; i < order.length; i++) {
        drawOrderItem(order[i])
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
        alert("������ ����� ������! ���� ����� ������")

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
    let userId = JSON.parse( sessionStorage.getItem("details"))[0].id
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
