
import HistoryOrderItem from "../HistoryOrderItem/HistoryOrderItem";
import styles from "./HistoryOrderStyle.module.css"

const HistoryOrder = () => {
    return (
        <div className={styles.container}>
            <h1 className={styles.elemName}>История заказов</h1>
            <h4 className={styles.ordersEmpty}>Сдесь пока ничего нет</h4>
            <div className={styles.orders}>
                <HistoryOrderItem/>
            </div>
        </div>
    )
}

export default HistoryOrder;