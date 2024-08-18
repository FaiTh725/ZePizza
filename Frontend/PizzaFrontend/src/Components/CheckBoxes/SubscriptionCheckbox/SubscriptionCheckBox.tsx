import Information from "../../Information/Information";
import styles from "./SubscriptionCeckBox.module.css"

import complete from "../../../assets/Inputs/complete.png"

const SubscptionCheckBox = () => {
    return (
        <div className={styles.container}>
            <div className={styles.check}>
                <img src={complete} alt="complete" />
            </div>
            <div className={styles.text}>
                Подписаться на рассылку
            </div>
            <div className={styles.additionInfromation}>
                <Information sizeImg={20}>
                    <p className={styles.information}>
                        Согласен на получение информации о специальных 
                        предложениях, новых продуктах и рекламных акциях
                        по электронной почте от ООО ZePizza
                    </p>
                </Information>
            </div>
        </div>
    )
}

export default SubscptionCheckBox;