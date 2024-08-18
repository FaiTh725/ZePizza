import DropDownList from "../../List/DropDownList/DropDownList";
import styles from "./BirthDayInput.module.css"



type BirthDay = {
    day: number;
    month: number;
    year: number
}

const BirthDayInput = () => {
    return (
        <div className={styles.container}>
            <div className={styles.fields}>
                <div className={styles.data}>
                    <DropDownList
                        label="День"
                        setValue={() => { }}
                        value={0}
                        values={[]}
                    />
                </div>
                <div className={styles.month}>
                    <DropDownList
                        label="Месяц"
                        setValue={() => { }}
                        value={0}
                        values={[]}
                    />
                </div>
                <div className={styles.year}>
                    <DropDownList
                        label="Год"
                        setValue={() => { }}
                        value={0}
                        values={[]}
                    />
                </div>
            </div>
            <div className={styles.btnContainer}>
                <button>Сохранить</button>
            </div>
        </div>
    )
}

export default BirthDayInput;