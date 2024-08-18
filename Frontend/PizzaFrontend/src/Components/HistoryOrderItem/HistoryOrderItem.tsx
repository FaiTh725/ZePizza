import { useState } from "react"

import styles from "./HistoryOrderItem.module.css"

import arrowDownGray from "../../assets/Inputs/arrowDownGray.png"
import arrowDownOrange from "../../assets/Inputs/arrowDownOrange.png"
import Order from "../Order/Order"

const HistoryOrderItem = () => {
    const [arrow, setArrow] = useState<string>(arrowDownGray);
    const [isOpenDetailOrder, setIsOPendetailOrder] = useState<boolean>(false);

    return (
        <div onMouseEnter={() => setArrow(arrowDownOrange)} onMouseLeave={() => {if(!isOpenDetailOrder) setArrow(arrowDownGray)}} className={styles.container  + ` ${isOpenDetailOrder ? styles.orangeBorder: ""}`}>
            <div onClick={() => {setIsOPendetailOrder(!isOpenDetailOrder); setArrow(arrowDownOrange)}} className={styles.shortInfo}>
                <section className={styles.idOrder}>
                    123244
                </section>
                <section className={styles.totalPrice}>
                    18.08.2024
                </section>
                <section>
                    100,99 руб.
                </section>
                <section className={styles.arrowImg}>
                    <img src={arrow} alt="arrow down" />
                </section>
            </div>
            <ul className={styles.orderItems + ` ${isOpenDetailOrder ? styles.orderVisible : styles.orderHidden}`}>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
            </ul>
        </div>
    )
}

export default HistoryOrderItem;