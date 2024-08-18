
import styles from "./Order.module.css"

import pizza from "../../assets/Pizzas/Pizza1.avif"

const Order = () => {
    return (
        <li className={styles.orderItem}>
            <div className={styles.pizzaImg}>
                <img src={pizza} alt="pizza image" />
            </div>
            <div className={styles.name}>
                Охотничья
            </div>
            <div className={styles.discription}>
                Баварские колбаски, много моцареллы, шампиньоны, соус, альфредо
            </div>
            <div className={styles.price}>
                13,99 руб.
            </div>
        </li>
    )
}

export default Order;