
import styles from "./FullScreenProduct.module.css"

import close from "../../assets/WindowsTools/close.png"
import { ReactNode } from "react";

interface FullScreenProductProps {
    isClose: boolean;
    setIsClose: (state:boolean) => void;
    children?: ReactNode
}

const FullScreenProduct = ({isClose, setIsClose, children}: FullScreenProductProps) => {
    return (
        <div onClick={() => {setIsClose(!isClose)}} className={styles.wrapper + ` ${isClose ? styles.open: styles.close}`}>
            <div onClick={(e) => {e.stopPropagation()}} className={styles.content}>
                <div className={styles.contentChildren}>
                    {children}
                </div>
                <div className={styles.closeBtnContainer}>
                    <button onClick={() => {setIsClose(!isClose)}}>
                        <img src={close} alt="close" width={30}/>
                    </button>
                </div>
            </div>
        </div>
    )
}

export default FullScreenProduct;